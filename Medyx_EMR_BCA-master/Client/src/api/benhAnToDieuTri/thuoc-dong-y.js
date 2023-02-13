import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/benh-an-thuoc-yhct-c`,
    method: "get",
    params: {
      ...params,
    },
  });
}
export function store(data) {   
  return request({
    url: `/benh-an-thuoc-yhct-c`,
    method: "post",
    data,
  });
}
export function update(idba, stt, data) {
  return request({
    url: `/benh-an-thuoc-yhct-c/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function updateYHCT(idba, stt, data) {
  return request({
    url: `/benh-an-thuoc-yhct/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function destroy(idba, stt) {
  return request({
    url: `/benh-an-thuoc-yhct-c/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function getYHCT(params) {  
  return request({
    url: `benh-an-thuoc-yhct`,
    method: "get",
    params,
  });
}
export function getThuocBaiThuoc(params) {
  return request({
    url: `/thuoc-bai-thuoc-c`,
    method: "get",
    params,
  });
}
export function storeFromBaiThuoc(data) {
  return request({
    url: `/benh-an-thuoc-yhct`,
    method: "post",
    data,
  });
}

//
export function ds_baiThuocDongY(params) {
  return request({
    url: `/thuoc-bai-thuoc`,
    method: "get",
    params: {
      maChungLoai: 3,
      ...params,
    },
  });
}
export function ds_thuocDongY(params) {
  return request({
    url: `/thuoc`,
    method: "get",
    params: {
      ...params,
      maChungLoai: 3,
      isWithRelation: true,
    },
  });
}
