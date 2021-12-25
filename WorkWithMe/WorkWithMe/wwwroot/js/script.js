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
    const message = await response.json();
    document.getElementById("message").innerText = message.text;
}