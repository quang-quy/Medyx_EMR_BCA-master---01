export function formatDatetime(value) {
  if (value)
    return (
      new Date(value).toLocaleDateString("en-GB") +
      " " +
      new Date(value).toLocaleTimeString("en-GB")
    ).substring(0, 16);
  else return null;
}

export function formatDate(value) {
  if (value) return new Date(value).toLocaleDateString("en-GB");
  else return null;
}

export function getFirstDayOfMonth() {
  const date = new Date();
  return new Date(date.getFullYear(), date.getMonth(), 1, 0, 0, 1);
}
