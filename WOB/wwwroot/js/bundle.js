// Calendarを表示するか判断するためのflag
let flag;

window.addEventListener("load", (event) => {
    console.log("page is fully loaded");
    DetermineFlag();
    if (flag) {
        ShowCalendar()
    }
});

// Calendarを表示する画面か判断
function DetermineFlag() {
    var calendarEl = document.getElementById('calendar');
    if (calendarEl != null) {
        flag = true;
    }
}

// カレンダー表示処理
function ShowCalendar() {
    console.log('ShowCalendarメソッドが呼ばれました')
    $.ajax({
        url: 'Events/GetEvents',
        type: "GET",
        dataType: "json",
        success: function (data) {
            console.log('データの取得に成功しました');
            GenerateCalendar(data);
        },
        error: function () {
            console.log('カレンダーの作成に失敗しました');
        }
    });
}

// カレンダー生成処理
function GenerateCalendar(data) {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        events: data,
        displayEventTime: false
    });
    calendar.render();
}