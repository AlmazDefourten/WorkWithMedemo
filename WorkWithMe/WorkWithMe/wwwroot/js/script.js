document.getElementById("sendBtn").addEventListener("click", sendJSON);
async function sendJSON(e) {
    e.preventDefault();
    const response = await fetch("/home/getuser", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            nick: document.getElementById("nick").value,
            email: document.getElementById("email").value,
            password: document.getElementById("password").value
        })
    });
    const message = (await response.json())["text"];
    let parsedMessage = JSON.parse(message);
    let nick = parsedMessage["Nick"];
    let id = parsedMessage["Id"];
    let email = parsedMessage["Email"];


    document.getElementById("message").innerText = "Nick: " +
        nick +
        " Email: " +
        email +
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

    const nickTd = document.createElement("td");
    nickTd.append(user.nick);
    tr.append(nickTd);

    const idTd = document.createElement("td");
    idTd.append(user.id);
    tr.append(idTd);

    const linksTd = document.createElement("td");

    tr.appendChild(linksTd);

    return tr;
}