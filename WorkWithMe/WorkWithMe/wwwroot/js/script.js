document.getElementById("sendBtn").addEventListener("click", sendJSON);
async function sendJSON(e) {
    e.preventDefault();
    const response = await fetch("/home/getuser", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            name: document.getElementById("name").value,
            lastname: document.getElementById("lastname").value
        })
    });
    const message = (await response.json())["text"];
    let parsedMessage = JSON.parse(message);
    let name = parsedMessage["Name"];
    let id = parsedMessage["Id"];
    let lastName = parsedMessage["LastName"];

    document.getElementById("message").innerText = "Name: " +
        name +
        " LastName: " +
        lastName +
        " Id: " + id;
}
document.getElementById("sendBtn").addEventListener("click", getUsers);
async function getUsers() {
    // отправляет запрос и получаем ответ
    const response = await fetch("/home/getusers", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    // если запрос прошел нормально
    if (response.ok === true) {
        // получаем данные
        const users = await response.json();
        const rows = document.querySelector("tbody");
        // добавляем полученные элементы в таблицу
        users.forEach(user => rows.append(row(user)));
    }
}
function row(user) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", user.id);

    const nameTd = document.createElement("td");
    nameTd.append(user.name);
    tr.append(nameTd);

    const ageTd = document.createElement("td");
    ageTd.append(user.id);
    tr.append(ageTd);

    const linksTd = document.createElement("td");

    tr.appendChild(linksTd);

    return tr;
}