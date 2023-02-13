import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/benh-an-thuoc-tay-y`,
    method: "get",
    params: {
      ...params,
    },
  });
}
export function store(data) {
  return request({
    url: `/benh-an-thuoc-tay-y`,
    method: "post",
    data,
  });
}
export function update(idba, stt, data) {
  return request({
    url: `/benh-an-thuoc-tay-y/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function destroy(idba, stt) {
  return request({
    url: `/benh-an-thuoc-tay-y/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function ds_thuocTayY(params) {
  return request({
    url: `/thuoc`,
    method: "get",
    params: {
      ...params,
      maChungLoai: [1, 2],
      isWithRelation: true,
    },
  });
}
