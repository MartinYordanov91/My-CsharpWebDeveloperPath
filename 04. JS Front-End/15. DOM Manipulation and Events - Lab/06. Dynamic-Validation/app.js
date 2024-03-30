function validate() {
    const inputElement = document.getElementById("email");
    const regex = /[a-z]+@[a-z]+\.[a-z]+/;
  
    function verify(e) {
      if (!regex.test(e.target.value)) {
        e.target.classList.add("error");
      } else {
        e.target.classList.remove("error");
      }
    }
  
    inputElement.addEventListener("change", verify);
  }
  