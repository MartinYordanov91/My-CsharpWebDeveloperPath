function search() {
  let listTownElements = Array.from(document.querySelectorAll("li"));
  let searchInput = document.getElementById("searchText").value;
  let resultTextArea = document.getElementById("result");

  let count = 0;

  listTownElements.forEach((element) => {
    if (searchInput.length > 0) {
      if (element.textContent.includes(searchInput)) {
        element.style.fontWeight = "bold";
        element.style.textDecoration = "underline";
        count++;
      }
    }
  });
  
  resultTextArea.textContent = `${count} matches found`;
}
