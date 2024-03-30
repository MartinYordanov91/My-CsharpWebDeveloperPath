let desimalNumber = 10;
let binaryNumber = desimalNumber.toString(2);
let hexaDesimalNumber = desimalNumber.toString(16).toUpperCase();

console.log(binaryNumber);




function attachGradientEvents() {
    const element = document.getElementById("gradient");
    const resultatElement = document.getElementById("result");
  
  element.addEventListener("mouseenter", function(event) {
      element.addEventListener("mousemove", function(event) {
        const rect = element.getBoundingClientRect();
        const offsetX = event.clientX - rect.left;
        resultatElement.textContent= `${Math.floor((offsetX/300)*100)}%`
      });
    
      element.addEventListener("mouseleave", function() {
        element.removeEventListener("mousemove");
      });
    })
  }
  