import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/dan-toc",
    method: "get",
    params,
  });
}
export function detail(id) {
  return request({
    url: `/dan-toc/${id}`,
    method: "get",
  });
}
export function update(id) {
  return request({
    url: `/dan-toc/${id}`,
    method: "put",
  });
}
export function detroy(id) {
  return request({
    url: `/dan-toc/${id}`,
    method: "delete",
  });
}

