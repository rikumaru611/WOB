using Bogus;
using WOB.Data;
using WOB.Models;

namespace WOB.Service
{
    /// <summary>
    /// ダミーデータ作成に関わるサービスをまとめました
    /// </summary>
    public class DammyDataService
    {
        const int number = 3;                

        public static void InsertDammyData(ApplicationDbContext db)
        {
            // Coachテーブルのダミーデータを作成する
            CreateCoach(db);

            //// Staffテーブルのダミーデータを作成する
            CreateStaff(db);

            //// Playerテーブルのダミーデータを作成する
            CreatePlayer(db);

            //// Userテーブルのダミーデータを作成する
            CreateUser(db);

            // Userテーブルのダミーデータを作成する
            // RuleSetを使用した
            CreateUserRef(db);

            // Eventテーブルのダミーデータを作成する
            CreateEvent(db);
        }

        /// <summary>
        /// コーチクラスのダミーデータを作成する
        /// </summary>
        /// <returns></returns>
        public static void CreateCoach(ApplicationDbContext _db)
        {
            var coach = new Faker<Coach>()
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName());

            List<Coach> MakeCoach(int seed)
            {
                return coach.UseSeed(seed).Generate(number);
            }

            //coach.var coachs = coach.Generate(number);

            // 毎回同じ値を作成する
            var coachs = MakeCoach(1330);
            _db.coaches.AddRange(coachs);
            _db.SaveChanges();         
        }

        public static List<Staff> CreateStaff(ApplicationDbContext _db)
        {
            var staff = new Faker<Staff>()
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName());

            var staffs = staff.Generate(number);
            _db.staffs.AddRange(staffs);
            _db.SaveChanges();
            return staffs;
        }

        public static void CreatePlayer(ApplicationDbContext _db)
        {
            // StatusIdをリストで受け取る
            List<int> statusIds = _db.statuses.Select(s => s.Id).ToList();

            var player = new Faker<Player>()
                // ここの繰り返しは仕方がなさそう
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                // ideal
                .RuleFor(s => s.Height, f => f.Random.Float()*2.0)
                .RuleFor(s => s.Weight, f => f.Random.Float()*130.0)
                //.RuleFor(s => s.Height, f => f.Random.Float())
                //.RuleFor(s => s.Weight, f => f.Random.Float())
                .RuleFor(s => s.StatusId, f => f.PickRandom(statusIds))
                ;
            var players = player.Generate(number);           
            _db.players.AddRange(players);
            _db.SaveChanges();
        }

        public static void CreateUser(ApplicationDbContext _db)
        {
            // userCodeIdを定義する
            const int staffUserCodeId = 1;
            const int coachUserCodeId = 2;
            const int playerUserCodeId = 3;

            List<int> numbers = _db.players.Select(p => p.Number).ToList();
            List<int> coachIds = _db.coaches.Select(c => c.Id).ToList();
            List<int> staffIds = _db.staffs.Select(s => s.StaffId).ToList();

            // Coachテーブルに紐づいたユーザーを作成する
            foreach(int id in coachIds){
                var user = new Faker<User>()                
                    .RuleFor(u => u.Mail, f => f.Internet.ExampleEmail())
                    .RuleFor(u => u.Tel, f => f.Random.Replace("###-####-####"))
                    .RuleFor(u => u.CoachId, f => id)
                    .RuleFor(u => u.UserCodeId, f => coachUserCodeId);
                _db.users.AddRange(user.Generate());
            }

            // Staffテーブルに紐づいたユーザーを作成する
            foreach (int id in staffIds)
            {
                var user = new Faker<User>()
                    .RuleFor(u => u.Mail, f => f.Internet.ExampleEmail())
                    .RuleFor(u => u.Tel, f => f.Random.Replace("###-####-####"))
                    .RuleFor(u => u.StaffId, f => id)
                    .RuleFor(u => u.UserCodeId, f => staffUserCodeId)
                    .RuleFor(u => u.CoachId, f => null);
                _db.users.AddRange(user.Generate());
            }

            // Playerテーブルに紐づいたユーザーを作成する
            foreach (int id in numbers)
            {
                var user = new Faker<User>()
                    .RuleFor(u => u.Mail, f => f.Internet.ExampleEmail())
                    .RuleFor(u => u.Tel, f => f.Random.Replace("###-####-####"))
                    .RuleFor(u => u.Number, f => id)
                    .RuleFor(u => u.UserCodeId, f => playerUserCodeId);
                var users = user.Generate();
                _db.users.AddRange(user.Generate());
            }
            _db.SaveChanges();
        }

        public static void CreateUserRef(ApplicationDbContext _db)
        {
            // userCodeIdを定義する
            const int staffUserCodeId = 1;
            const int coachUserCodeId = 2;
            const int playerUserCodeId = 3;

            List<int> numbers = _db.players.Select(p => p.Number).ToList();
            List<int> coachIds = _db.coaches.Select(c => c.Id).ToList();
            List<int> staffIds = _db.staffs.Select(s => s.StaffId).ToList();

            var user = new Faker<User>()                
                .RuleFor(u => u.Mail, f => f.Internet.ExampleEmail())
                .RuleFor(u => u.Tel, f => f.Random.Replace("###-####-####"));


            // Coachテーブルに紐づいたユーザーを作成する
            foreach (int id in coachIds)
            {
                user.RuleSet("Coach", set => set.Rules((f, u) =>
                {
                    u.CoachId = id;
                    u.UserCodeId = coachUserCodeId;
                }));
                    
                _db.users.AddRange(user.Generate("default, Coach"));
            }

            // Staffテーブルに紐づいたユーザーを作成する
            foreach (int id in staffIds)
            {
                user.RuleSet("Staff", set => set.Rules((f, u) =>
                {
                    u.StaffId = id;
                    u.UserCodeId = staffUserCodeId;
                }));                
                _db.users.AddRange(user.Generate("default, Staff"));
            }

            // Playerテーブルに紐づいたユーザーを作成する
            foreach (int id in numbers)
            {
                user.RuleSet("Player", set => set.Rules((f, u) =>
                {
                    u.Number = id;
                    u.UserCodeId = playerUserCodeId;
                }));
                _db.users.AddRange(user.Generate("default, Player"));
            }
            _db.SaveChanges();
        }

        /// <summary>
        /// Eventテーブルを作成する
        /// </summary>
        /// <param name="_db"></param>
        public static void CreateEvent(ApplicationDbContext db)
        {
            List<EventType> eventTypes = db.eventTypes.ToList();
            var faker = new Faker<Event>()                
                .RuleFor(e => e.Name, f => f.Lorem.Word())
                .RuleFor(e => e.EventTypeId, f => f.PickRandom(eventTypes).Id)                
                .RuleFor(e => e.Date, f => f.Date.Between(DateTime.Now, DateTime.Now.AddYears(1)))
                .RuleFor(e => e.MeetingTime, f => f.Date.Between(DateTime.Now, DateTime.Now.AddMinutes(f.Random.Int())))
                .RuleFor(e => e.DismissalTime, (f, e) => e.MeetingTime.AddMinutes(f.Random.Int()))
                .RuleFor(e => e.Place, f => f.Lorem.Word())
                .RuleFor(e => e.Description, f => f.Lorem.Letter())
                .RuleFor(e => e.Valid, true)
                ;
            var events = faker.Generate(number);
            db.events.AddRange(events);
            db.SaveChanges();
        }

    }
}
