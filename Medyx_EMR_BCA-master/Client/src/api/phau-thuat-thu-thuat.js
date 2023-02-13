import request from "@/utils/request";

export function index(idba, params) {
    return request({
        url: "/benh-an-phau-thuat",
        method: "get",
        params: {
            idba,
            ...params,
        },
    });
}

// Bệnh án duyệt mổ
export function addBenhAnDuyetMo(data) {
    return request({
      url: `/benh-an-phau-thuat-duyet-mo`,
      method: "post",
      data
    });
  }
export function detailBenhAnDuyetMo(idba, stt) {
    return request({
        url: `/benh-an-phau-thuat-duyet-mo/${idba}/chi-tiet/${stt}`,
        method: "get",
    });
}
export function updateBenhAnDuyetMo(idba, stt, data) {
    return request({
        url: `/benh-an-phau-thuat-duyet-mo/${idba}/chi-tiet/${stt}`,
        method: "put",
        data
    });
}
export function detroyBenhAnDuyetMo(idba, stt) {
    return request({
        url: `/benh-an-phau-thuat-duyet-mo/${idba}/chi-tiet/${stt}`,
        method: "delete",
    });
}

// Phiếu khám gây mê
export function addPhieuKhamGayMe(data) {
    return request({
      url: `/benh-an-phau-thuat-phieu-kham-gay-me-truoc-mo`,
      method: "post",
      data
    });
  }
export function detailPhieuKhamGayMe(idba, stt) {
    return request({
        url: `/benh-an-phau-thuat-phieu-kham-gay-me-truoc-mo/${idba}/chi-tiet/${stt}`,
        method: "get",
    });
}
export function updatePhieuKhamGayMe(idba, stt, data) {
    return request({
        url: `/benh-an-phau-thuat-phieu-kham-gay-me-truoc-mo/${idba}/chi-tiet/${stt}`,
        method: "put",
        data
    });
}
export function detroyPhieuKhamGayMe(idba, stt) {
    return request({
        url: `/benh-an-phau-thuat-phieu-kham-gay-me-truoc-mo/${idba}/chi-tiet/${stt}`,
        method: "delete",
    });
} 

//Phiếu phẫu thuật
export function addPhieuPhauThuat(data) {
    return request({
      url: `/benh-an-phau-thuat-phieu-pttt`,
      method: "post",
      data
    });
  }
export function detailPhieuPhauThuat(idba, stt) {
    return request({
        url: `/benh-an-phau-thuat-phieu-pttt/${idba}/chi-tiet/${stt}`,
        method: "get",
    });
}
export function updatePhieuPhauThuat(idba, stt, data) {
    return request({
        url: `/benh-an-phau-thuat-phieu-pttt/${idba}/chi-tiet/${stt}`,
        method: "put",
        data
    });
}
export function detroyPhieuPhauThuat(idba, stt) {
    return request({
        url: `/benh-an-phau-thuat-phieu-pttt/${idba}/chi-tiet/${stt}`,
        method: "delete",
    });
}
