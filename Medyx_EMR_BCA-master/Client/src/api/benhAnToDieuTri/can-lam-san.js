import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/benh-an-cls`,
    method: "get",
    params: {
      ...params,
      withKQ: false,
    },
  });
}
export function store(data) {
  var tempt = data;
  tempt.capCuuBoolean ? (tempt.capCuu = 1) : (tempt.capCuu = 0);
  return request({
    url: `benh-an-cls/to-dieu-tri`,
    method: "post",
    data: tempt,
  });
}
export function storeGoiCls(data) {
  return request({
    url: `benh-an-cls/to-dieu-tri`,
    method: "post",
    data,
  });
}
export function update(idba, stt, data) {
  var tempt = data;
  tempt.capCuuBoolean ? (tempt.capCuu = 1) : (tempt.capCuu = 0);
  return request({
    url: `/benh-an-cls/${idba}/chi-tiet/${stt}/to-dieu-tri`,
    method: "put",
    data : tempt,
  });
}
export function destroy(idba, stt) {
  return request({
    url: `benh-an-cls/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}

//
export function ds_GoiCanLamSans(params) {
  return request({
    url: `/dm-dich-vu-goi`,
    method: "get",
    params: {
      excludeLoai: 5,
      sortBy: "maGoi",
      ...params,
    },
  });
}
export function ds_dVCanLamSans(params) {
  return request({
    url: `/dm-dich-vu`,
    method: "get",
    params: {
      ...params,
      excludeMaChungLoai: 5,
    },
  });
}
