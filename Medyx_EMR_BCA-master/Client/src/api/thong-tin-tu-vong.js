import request from "@/utils/request";
export function indexKdtv(idba) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/bien-ban-kiem-diem/${idba}`,
    method: "get",
  });
}
export function storeKdtv(data) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/bien-ban-kiem-diem`,
    method: "post",
    data,
  });
}
export function updateKdtv(idba, data) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/bien-ban-kiem-diem/${idba}`,
    method: "put",
    data,
  });
}
export function destroyKdtv(idba) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/bien-ban-kiem-diem/${idba}`,
    method: "delete",
  });
}

/******thanh vien tham gia********* */
export function indexTvtg(params) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/bien-ban-kiem-diem/thanh-vien-tham-gia`,
    method: "get",
    params,
  });
}
export function storeTvtg(data) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/bien-ban-kiem-diem/thanh-vien-tham-gia`,
    method: "post",
    data,
  });
}
export function updateTvtg(idba, stt, data) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/bien-ban-kiem-diem/thanh-vien-tham-gia/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function destroyTvtg(idba, stt) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/bien-ban-kiem-diem/thanh-vien-tham-gia/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}

// Phie chuan doan

export function indexCdnn(idba) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/chan-doan-nguyen-nhan/${idba}`,
    method: "get",
  });
}
export function storeCdnn(data) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/chan-doan-nguyen-nhan`,
    method: "post",
    data,
  });
}
export function updateCdnn(idba, data) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/chan-doan-nguyen-nhan/${idba}`,
    method: "put",
    data,
  });
}
export function destroyCdnn(idba) {
  return request({
    url: `/benh-an-thong-tin-tu-vong/chan-doan-nguyen-nhan/${idba}`,
    method: "delete",
  });
}
// Print
export function printBBKd(idba, maba) {
  return window.open(
    `${window.origin}/api/benh-an-thong-tin-tu-vong/${idba}/print-ba-file/kiem-diem-tu-vong/${maba}.pdf`,
    "_blank"
  );
}
export function printInTrich(idba, maba) {
  return window.open(
    `${window.origin}/api/benh-an-thong-tin-tu-vong/${idba}/print-ba-file/trich-bien-ban/${maba}.pdf`,
    "_blank"
  );
}
export function printGbt(idba, maba) {
  return window.open(
    `${window.origin}/api/benh-an-thong-tin-tu-vong/${idba}/print-ba-file/giay-bao-tu/${maba}.pdf`,
    "_blank"
  );
}
export function printChuanDoan(idba, maba) {
  return window.open(
    `${window.origin}/api/benh-an-thong-tin-tu-vong/${idba}/print-ba-file/chuan-doan-nguyen-nhan/${maba}.pdf`,
    "_blank"
  );
}
