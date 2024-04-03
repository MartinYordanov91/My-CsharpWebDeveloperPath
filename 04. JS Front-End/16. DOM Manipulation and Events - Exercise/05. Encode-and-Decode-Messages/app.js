function encodeAndDecodeMessages() {
    const [encodeContainer, decodeContainer] = Array.from(
      document.querySelectorAll("#main div")
    );
  
    const encodeButton = encodeContainer.querySelector("button");
    const decodeButton = decodeContainer.querySelector("button");
    const encodeTextArea = encodeContainer.querySelector("textarea");
    const decodeTextArea = decodeContainer.querySelector("textarea");
  
    encodeButton.addEventListener("click", encode);
    decodeButton.addEventListener("click", decode);
  
    function encode() {
      const originalText = encodeTextArea.value;
      let encodedText = "";
      for (let char of originalText) {
        const charCode = char.charCodeAt(0);
        encodedText += String.fromCharCode(charCode + 1);
      }
      decodeTextArea.value = encodedText;
      encodeTextArea.value = "";
    }
  
    function decode() {
      const encodedText = decodeTextArea.value;
      let decodedText = "";
      for (let char of encodedText) {
        const charCode = char.charCodeAt(0);
        decodedText += String.fromCharCode(charCode - 1);
      }
      decodeTextArea.value = decodedText;
    }
  }