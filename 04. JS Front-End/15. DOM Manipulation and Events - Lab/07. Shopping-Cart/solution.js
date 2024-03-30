function solve() {
  const textAreaElement = document.querySelector("textarea");
  const checkOutElement = document.querySelector(".checkout");
  const allProductsElement = Array.from(document.querySelectorAll(".product"));
  const allButonsElement = Array.from(document.querySelectorAll("button"));

  let array = [];
  let totalPrice = 0;

  allProductsElement.forEach((element) => {
    const productTitle = element.querySelector(".product-title");
    const productButonAdd = element.querySelector(".add-product");
    const productPrice = element.querySelector(".product-line-price");

    productButonAdd.addEventListener("click", onClick);

    function onClick(e) {
      textAreaElement.textContent += `Added ${
        productTitle.textContent
      } for ${Number(productPrice.textContent).toFixed(2)} to the cart.\n`;

      array.includes(productTitle.textContent)
        ? ""
        : array.push(productTitle.textContent);

      totalPrice += Number(productPrice.textContent);
    }
  });

  checkOutElement.addEventListener("click",endShoping)

  function endShoping(e) {
   allButonsElement.forEach(element=>{
      element.disabled = true;
   })
   
   textAreaElement.textContent += `You bought ${array.join(", ")} for ${totalPrice.toFixed(2)}.`
  }
}
