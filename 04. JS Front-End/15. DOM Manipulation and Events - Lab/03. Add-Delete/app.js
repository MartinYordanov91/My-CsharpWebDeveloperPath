function addItem() {
  const textInputElement = document.getElementById("newItemText");
  const listElement = document.getElementById("items");
  const newRowElement = document.createElement("li");
  const newLinkElement = document.createElement("a");

  newRowElement.textContent = textInputElement.value;
  newLinkElement.href ='#'
  newLinkElement.textContent ="[Delete]" 

  newLinkElement.addEventListener("click" ,(e)=>{
    newRowElement.remove()
  })
  newRowElement.appendChild(newLinkElement)
  listElement.appendChild(newRowElement)
}
