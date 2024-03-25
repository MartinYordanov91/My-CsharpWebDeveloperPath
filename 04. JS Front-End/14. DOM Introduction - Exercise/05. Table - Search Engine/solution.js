function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    const trElements = Array.from(document.querySelectorAll("tbody tr"));
    const searchFieldElement = document.getElementById("searchField");

    trElements.forEach((tableRol) => {
      if (tableRol.textContent.includes(searchFieldElement.value)) {
        tableRol.classList.add("select");
      } else {
        tableRol.classList.remove("select");
      }
    });

    searchFieldElement.value = "";
  }
}
