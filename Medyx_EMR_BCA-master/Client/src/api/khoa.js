import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/khoa",
    method: "get",
    params,
  });
}
export function detail(id) {
  return request({
    url: `/khoa/${id}`,
    method: "get",
  });
}
export function update(id) {
  return request({
    url: `/khoa/${id}`,
    method: "put",
  });
}
export function detroy(id) {
  return request({
    url: `/khoa/${id}`,
    method: "delete",
  });
}

