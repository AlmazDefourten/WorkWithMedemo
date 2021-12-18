let data = JSON.stringify({ "name":
name.value, "lastname": lastname.value });

async function sendJSON(e) {
    e.preventDefault();
    const response = await fetch("/api/user", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            name: document.getElementById("name").value,
            lastname: document.getElementById("lastname").value
        })
    });
    const message = await response.json();
    document.getElementById("message").innerText = message.text;
}