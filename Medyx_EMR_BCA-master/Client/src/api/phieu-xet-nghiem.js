import request from "@/utils/request";
export function index(idba, params) {
  return request({
    url: `/benh-an-cls`,
    method: "get",
    params: {
      idba,
      maChungLoai: 2,
      withKQ: false,
      ForPhieuXetNghiem:true, 
      ...params,
    },
  });
}
export function update(idba, stt, data) {
  return request({
    url: `/benh-an-phieu-xet-nghiem/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function destroy(idba, stt) {
  return request({
    url: `/benh-an-phieu-xet-nghiem/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}

export async function print(idba ,params) {
  window.open(
    `${window.origin}/api/benh-an-phieu-xet-nghiem/${idba}/print-ba-file/Phieuxetnghiem.pdf?${params}`,
    "_blank"
  );
  return;
}

export function getKhoas(params) {
  return request({
    url: "/khoa",
    method: "get",
    params,
  });
}
export function getNhanVien(params) {
  return request({
    url: "/dm-nhan-vien",
    method: "get",
    params,
  });
}

// detail table children
export function detail(params) {
  return request({
    url: `/benh-an-phieu-xet-nghiem`,
    method: "get",
    params,
  });
}
export function handleUpDateCrete(data) {
  return request({
    url: `/benh-an-phieu-xet-nghiem`,
    method: "post",
    data,
  });
}
