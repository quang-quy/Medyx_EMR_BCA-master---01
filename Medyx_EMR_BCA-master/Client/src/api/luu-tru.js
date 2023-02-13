import request from "@/utils/request";

export function getThongTinLuuTru(id) {
  return request({
    url: "/benh-an-report/luu-tru/" + id,
    method: "get",
  });
}

export function getThongTinReport(id) {
  return request({
    url: "/benh-an-report/check-report-generation/" + id,
    method: "get",
  });
}
export function generateReport(id, name) {
  return request({
    url: `/benh-an-report/${name}/${id}`,
    method: "get",
  });
}
export function luuTru(id, data) {
  return request({
    url: "/benh-an-report/luu-tru/" + id,
    method: "post",
    data,
  });
}

export function khoiPhuc(id) {
  return request({
    url: "/benh-an-report/khoi-phuc/" + id,
    method: "get",
  });
}

export function reset(id) {
  return request({
    url: "/benh-an-report/reset/" + id,
    method: "get",
  });
}
