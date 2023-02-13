import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/benh-an-cpm`,
    method: "get",
    params,
  });
}
export function show(idba, stt) {
  return request({
    url: `/benh-an-cpm/${idba}/chi-tiet/${stt}`,
    method: "get",
  });
}

export function update(data) {
  return request({
    url: `/benh-an-theo-doi-truyen-mau`,
    method: "post",
    data,
  });
}
export function store(data) {
  return request({
    url: `/benh-an-theo-doi-truyen-mau`,
    method: "post",
    data,
  });
}
export function destroy(idba, stt) {
  return request({
    url: `/benh-an-cpm/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function dsChePhamMaus(params) {
  return request({
    url: `/dm-che-pham-mau`,
    method: "get",
  });
}

export function detail(idba, stt) {
  return request({
    url: `/benh-an-theo-doi-truyen-mau/${idba}/chi-tiet/${stt}`,
    method: "get",
  });
}
export function print(idba, stt) {
  window.open(
    `${window.origin}/api/benh-an-theo-doi-truyen-mau/${idba}/print-ba-file/${stt}/ThongTinTruyenMau_idba_${idba}.pdf`,
    "_blank"
  );
  return;
}

export function indexC(params) {
  return request({
    url: `/benh-an-theo-doi-truyen-mau-c`,
    method: "get",
    params,
  });
}
export function storeC(data) {
  return request({
    url: `/benh-an-theo-doi-truyen-mau-c`,
    method: "post",
    data,
  });
}
export function updateC(idba, stt, data) {
  return request({
    url: `/benh-an-theo-doi-truyen-mau-c/${idba}/chi-tiet/${stt}`,
    method: "put",
    data: {
      ...data,
      stttruyenMau: stt,
    },
  });
}
export function detroyC(idba, stt) {
  return request({
    url: `/benh-an-theo-doi-truyen-mau-c/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
