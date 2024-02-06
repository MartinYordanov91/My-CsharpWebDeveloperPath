function circleArea(some) {
  if (typeof some === "number") {
    console.log((some * some * 3.14159265359).toFixed(2));
  } else {
    console.log(
      `We can not calculate the circle area, because we receive a ${typeof some}.`
    );
  }
}

circleArea(5);
circleArea(`name`);
