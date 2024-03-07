function pointValidator(pointArray) {
  const [x1, y1, x2, y2] = pointArray;

  function calcolatePoints(x1, y1, x2, y2) {
    let isValide = Number.isInteger(
      Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2))
    );
    
    isValide
      ? console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
      : console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
  }

  calcolatePoints(x1, y1, 0, 0);
  calcolatePoints(x2, y2, 0, 0);
  calcolatePoints(x1, y1, x2, y2);
}

pointValidator([3, 0, 0, 4]);
pointValidator([2, 1, 1, 1]);
