document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {

        aspectRatio: 2.2,
        initialView: 'dayGridMonth',
        timeZone: 'local',
        initialDate: new Date,
        navLinks: true,
        editable: true,
        selectable: true,
        nowIndicator: true,
        dayMaxEvents: true,
        selectMirror: true,
        weekNumbers: true,
        headerToolbar: {
            start: 'prevYear,prev,next,nextYear today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        dateClick: function (info) {
            $("#dialog").dialog("open");
        },
        eventClick: function (arg) {
            if (confirm('Are you sure you want to delete this event?')) {
                arg.event.remove()
            }
        },
        events: [
            {
                title: 'All Day Event',
                start: '2020-07-07'
            },
            {
                title: 'Long Event',
                start: '2020-07-07',
                end: '2020-07-10'
            },
            {
                groupId: '999',
                title: 'Repeating Event',
                start: '2020-07-09T16:00:00'
            },
            {
                groupId: '999',
                title: 'Repeating Event',
                start: '2020-07-16T16:00:00'
            },
            {
                title: 'Conference',
                start: '2020-07-11',
                end: '2020-07-13'
            },
            {
                title: 'Meeting',
                start: '2020-07-12T10:30:00',
                end: '2020-07-12T12:30:00'
            },
            {
                title: 'Lunch',
                start: '2020-0-12T12:00:00'
            },
            {
                title: 'Meeting',
                start: '2020-07-12T14:30:00'
            },
            {
                title: 'Birthday Party',
                start: '2020-07-13T07:00:00'
            },
            {
                title: 'Click for Google',
                url: 'http://google.com/',
                start: '2020-07-28'
            }
        ],
    });
    calendar.render();
    $('#dialog').dialog({ autoOpen: false });
    $("#opener").click(function () {
        $("#dialog").dialog("open");
    });
    $('.datepicker').datepicker({
        dateFormat: "yy-mm-dd"
    });
});