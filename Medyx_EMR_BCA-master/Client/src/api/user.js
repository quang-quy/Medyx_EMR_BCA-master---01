import request from "@/utils/request";

export function login(data) {
  return request({
    url: "/auth/login",
    method: "post",
    data,
  });
}

export function getInfo() {
  return request({
    url: "/auth/me",
    method: "get",
  });
}

export function logout() {
  return request({
    url: "/auth/logout",
    method: "post",
  });
}

export function changePassword(data) {
  return request({
    url: "/auth/password/change",
    method: "post",
    data,
  });
}


export function index(params) {
  return request({
    url: "http://localhost:3333/api/users",
    method: "get",
    params,
  });
}
export function update(id, data) {
  return request({
    url: "http://localhost:3333/api/users/" + id,
    method: "put",
    data,
  });
}

export function store(data) {
  return request({
    url: "http://localhost:3333/api/users",
    method: "post",
    data,
  });
}
export function destroy(id) {
  return request({
    url: "http://localhost:3333/api/users/" + id,
    method: "delete",
  });
}

export function getRoles(params) {
  return request({
    url: "http://localhost:3333/api/roles",
    method: "get",
    params,
  });
}