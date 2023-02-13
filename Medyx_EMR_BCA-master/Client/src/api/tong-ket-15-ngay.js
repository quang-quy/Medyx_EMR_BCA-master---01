import request from "@/utils/request";

export function index(idba, params) {
  return request({
    url: "/benh-an-tong-ket-15-ngay",
    method: "get",
    params: {
      idba,
      ...params,
    },
  });
}
export function detail(id) {
  return request({
    url: `/benh-an-tong-ket-15-ngay/${id}`,
    method: "get",
  });
}
export function update(id) {
  return request({
    url: `/benh-an-tong-ket-15-ngay/${id}`,
    method: "put",
  });
}
export function destroy(idba,stt) {
  return request({
    url: `/benh-an-tong-ket-15-ngay/${idba}/xoa/${stt}`,
    method: "delete",
  });
}
export function addTongKetDieuTri(idba,data){
  return request({
    url: `/benh-an-tong-ket-15-ngay/${idba}/them-moi`,
    method: "post",
    data
  });
}
export function updateTongKetDieuTri(idba,stt,data){
  return request({
    url: `/benh-an-tong-ket-15-ngay/${idba}/cap-nhat/${stt}`,
    method: "put",
    data
  });
}

export async function print(idba, stt) {
  window.open(
    `${window.origin}/api/benh-an-tong-ket-15-ngay/${idba}/print-ba-file/${stt}/tongket15ngaydieutri.pdf`,
    "_blank"
  );
  return;
}