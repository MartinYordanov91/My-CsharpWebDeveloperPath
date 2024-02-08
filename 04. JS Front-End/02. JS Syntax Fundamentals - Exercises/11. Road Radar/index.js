function radar(speed, area) {
  const limitedSpeed = {
    motorway: 130,
    interstate: 90,
    city: 50,
    residential: 20,
  };

  const unlimitedSpeed = speed - limitedSpeed[area];

  if (unlimitedSpeed <= 0) {
    console.log(`Driving ${speed} km/h in a ${limitedSpeed[area]} zone`);
    return;
  }

  let status =
    unlimitedSpeed <= 20
      ? "speeding"
      : unlimitedSpeed <= 40
      ? "excessive speeding"
      : "reckless driving";

      console.log(`The speed is ${unlimitedSpeed} km/h faster than the allowed speed of ${limitedSpeed[area]} - ${status}`)
}

radar(40, "city");
radar(21, 'residential');
radar(120, 'interstate');
radar(200, 'motorway');
