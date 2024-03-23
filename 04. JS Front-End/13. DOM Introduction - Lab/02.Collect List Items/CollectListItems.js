function extractText() {
    let unOrderListElement = document.getElementById("items")
    let textAreaElement = document.getElementById("result")

    textAreaElement.textContent = unOrderListElement.textContent
}