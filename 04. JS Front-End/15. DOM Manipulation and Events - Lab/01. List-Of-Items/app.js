function addItem() {
  const listElement = document.getElementById("items");
  const textInputElement = document.getElementById("newItemText");
  const newElement = document.createElement("li");
  newElement.textContent = textInputElement.value;
  listElement.appendChild(newElement);
}
