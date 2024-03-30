function attachGradientEvents() {
    const gradientElement = document.getElementById('gradient');
    const resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', gradientIn)
    gradientElement.addEventListener('mouseout', gradientOut)

    function gradientIn(e) {
            const gradientWidth = gradientElement.clientWidth -1;
            const mouseX = e.offsetX;
      
            const percentage = Math.trunc((mouseX / gradientWidth) * 100);
            resultElement.textContent = percentage + '%';
          
    }

    function gradientOut(e){
        resultElement.textContent =""
    }
  }