import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/dien-bien-benh`,
    method: "get",
    params: {
      ...params,
    },
  });
}
export function update(idba, stt, data) {
  return request({
    url: `/benh-an-to-dieu-tri/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function destroy(id) {
  return request({
    url: `/dien-bien-benh/${id}`,
    method: "delete",
  });
}
