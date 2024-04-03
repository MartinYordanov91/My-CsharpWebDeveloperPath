function lockedProfile() {
  const allUsers = Array.from(document.querySelectorAll(".profile"));

  allUsers.forEach((element) => {
    const butonElement = element
      .querySelector("button")
      .addEventListener("click", onClick);
  });

  function onClick(e) {
    const isLockElement = e.target.parentNode.querySelector("input");
    const hidenElement = e.target.parentNode.querySelector("div");
    if (isLockElement.checked) {
      return;
    }

    const isHiden = e.target.textContent === "Show more";

    hidenElement.style.display = isHiden ? "block" : "none";
    e.target.textContent = isHiden ? "Hide it" : "Show more";
  }
}
