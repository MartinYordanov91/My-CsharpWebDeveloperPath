function ageDetermination(age) {
  const persenDeterminate =
    age < 0
      ? "out of bounds"
      : age <= 2
      ? "baby"
      : age <= 13
      ? "child"
      : age <= 19
      ? "teenager"
      : age <= 65
      ? "adult"
      : "elder";

  console.log(persenDeterminate);
}

ageDetermination(20)
ageDetermination(1)
ageDetermination(100)
ageDetermination(-1)