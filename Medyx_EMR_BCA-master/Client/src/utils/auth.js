export function getAuth() {
  return !!localStorage.getItem("auth");
}

export function setAuth(val) {
  val ? localStorage.setItem("auth", true) : localStorage.removeItem("auth");
}
