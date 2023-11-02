using Bogus;
using WOB.Data;
using WOB.Models;

namespace WOB.Service
{
    /// <summary>
    /// ダミーデータ作成に関わるサービスをまとめました
    /// </summary>
    public class DammyData
    {
        const int number = 3;

        private static readonly ApplicationDbContext _db;

        public static void InsertDammyData(ApplicationDbContext db)
        {
            // Coachテーブルのダミーデータを作成する

            // Staffテーブルのダミーデータを作成する

            // Playerテーブルのダミーデータを作成する

            // Userテーブルのダミーデータを作成する

        }

        /// <summary>
        /// コーチクラスのダミーデータを作成する
        /// </summary>
        /// <returns></returns>
        public static void CreateCoach()
        {
            var coach = new Faker<Coach>()
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName());
            
            var coachs = coach.Generate(number);
            _db.coaches.AddRange(coachs);
            _db.SaveChanges();
        }

        public static List<Staff> CreateStaff()
        {
            var staff = new Faker<Staff>()
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName());

            var staffs = staff.Generate(number);
            _db.staffs.AddRange(staffs);
            _db.SaveChanges();
            return staffs;
        }

        public static void CreatePlayer()
        {
            // StatusIdをリストで受け取る
            List<int> statusIds = _db.statuses.Select(s => s.Id).ToList();

            var player = new Faker<Player>()
                // ここの繰り返しは仕方がなさそう
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Height, f => f.Random.Float()*2.3)
                .RuleFor(s => s.Weight, f => f.Random.Float() * 130)
                .RuleFor(s => s.StatusId, f => f.PickRandom(statusIds))
                ;
            var players = player.Generate(number);           
            _db.players.AddRange(players);
            _db.SaveChanges();
        }

        public static void CreateUser()
        {
            // Coach

        }


    }
}
