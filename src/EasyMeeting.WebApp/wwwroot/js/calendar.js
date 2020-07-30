function click() {
    const title = document.getElementById('title').value;
    const start = document.getElementById('start').value;
    const duration = document.getElementById('duration').value;
    const end = document.getElementById('end').value;
    const address = document.getElementById('address').value;
    const description = document.getElementById('description').value;
    const email = document.getElementById('email').value;

    const calendar = createCalendar({
        options: {
            class: 'my-class',
            id: 'my-id'
        },
        data: {
            email: email,
            title: title,
            start: new Date(start),
            duration: duration,
            end: new Date(end),
            address: address,
            description: description
        }
    });

    console.log(calendar);
    const data = calendar.querySelector(".icon-google");
    console.log(data.href);
    document.getElementById('calendar').value = data;
}

function main() {
    document.getElementById('button').addEventListener('click', click);
}


document.addEventListener('DOMContentLoaded', main);
