function solve(arr) {
    return arr
      .filter((num, i) => i % 2 == 1)
      .map(x => 2 * x)
      .reverse().join(' ');
  }