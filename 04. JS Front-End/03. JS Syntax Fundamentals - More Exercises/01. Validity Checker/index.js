function cordinateValidator(x1, y1, x2, y2) {
    
  function validate(x1, y1, x2, y2) {
    let curentNum = Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    let isValid = Number.isInteger(curentNum) ? "valid" : "invalid";
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${isValid}`);
  }

  validate(x1, y1, 0, 0);
  validate(x2, y2, 0, 0);
  validate(x1, y1, x2, y2);
}

cordinateValidator(3, 0, 0, 4);
cordinateValidator(2, 1, 1, 1);
