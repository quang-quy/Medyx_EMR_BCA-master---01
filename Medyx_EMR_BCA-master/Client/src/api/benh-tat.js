import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/dm-benh-tat",
    method: "get",
    params,
    cache: true,
  });
}
export function detail(id) {
  return request({
    url: `/dm-benh-tat/${id}`,
    method: "get",
  });
}
export function update(id) {
  return request({
    url: `/dm-benh-tat/${id}`,
    method: "put",
  });
}
export function detroy(id) {
  return request({
    url: `/dm-benh-tat/${id}`,
    method: "delete",
  });
}

