<template>
  <component
    :is="edit ? 'AppWrapper' : 'Fragment'"
    :showThongTinChungBenhAn="false"
  >
    <div
      :class="{ 'ma-5': edit, 'pb-5': !edit, 'thong-tin-benh-an-chung': true }"
    >
      <div class="d-flex justify-space-between align-flex-end mb-3">
        <div>
          <div style="font-size: 20px; font-weight: bold">
            Thông tin chung bệnh án
          </div>
          <div>
            <i>(<span class="red-dot">*</span>) : Mục bắt buộc</i>
          </div>
        </div>
        <div>
          <div>
            <v-btn
              v-if="edit && currentUser.is_admin"
              color="primary"
              class="mr-2"
              @click="updateData(true)"
              small
              :disabled="!action.close"
            >
              <v-icon small left> mdi-close </v-icon>Cập nhật đóng bệnh án
            </v-btn>
            <v-btn
              :disabled="!!benhAn.xacNhanKetThucHs || !action.modify"
              v-if="edit"
              color="primary"
              @click="submit('ruleForm')"
              small
            >
              <v-icon small left> mdi-pencil </v-icon>Cập nhật
            </v-btn>
            <v-btn v-else color="primary" small @click="submit('ruleForm')">
              <v-icon small left> mdi-plus </v-icon>Thêm mới
            </v-btn>
            <v-btn small @click="exit" class="ml-2" color="primary"
              ><v-icon>mdi-exit-to-app</v-icon> Thoát(F10)</v-btn
            >
          </div>
        </div>
      </div>
      <v-progress-linear
        color="primary"
        rounded
        value="100"
        height="2"
      ></v-progress-linear>
      <br />
      <el-form :model="form" :rules="rules" ref="ruleForm">
        <v-row>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="2"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="1. Loại bệnh án" prop="maLoaiBa">
              <el-select
                size="small"
                v-model="form.maLoaiBa"
                placeholder="Tìm kiếm theo tên phân loại"
              >
                <el-option
                  v-for="(item, index) in phanLoaiBenhAn"
                  :key="index"
                  :value="item.maLoaiBa"
                  :label="item.tenLoaiBa"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="2"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="2. Mã bệnh án">
              <el-input
                size="small"
                v-model="benhAn.maBa"
                placeholder="Mã bệnh án"
                :disabled="true"
              >
              </el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="2"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="3. Số vào viện" prop="soVaoVien">
              <el-input
                size="small"
                v-model="form.soVaoVien"
                placeholder="VD: 123456"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="2"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="4. Số lưu trữ">
              <el-input
                size="small"
                v-model="benhAn.soLuuTru"
                placeholder="VD: 123456"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="2"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="5. Mã người bệnh" prop="maBn">
              <el-input
                size="small"
                v-model="form.maBn"
                placeholder="VD: 123456"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="2"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="6. Mã YT" prop="maYt">
              <el-input
                size="small"
                v-model="form.maYt"
                placeholder="VD: 123456"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="4"
            lg="4"
            xl="4"
            class="padding-cols"
          >
            <el-form-item label="7. Họ tên người bệnh" prop="hoTen">
              <el-input
                size="small"
                v-model="form.hoTen"
                placeholder="VD: Nguyễn văn A"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="8. Ngày sinh" prop="ngaySinh">
              <el-date-picker
                type="date"
                size="small"
                style="width: 100%"
                format="dd/MM/yyyy"
                value-format="yyyy-MM-ddTHH:mm:ss"
                v-model="form.ngaySinh"
                placeholder="23/04/2000"
                :picker-options="pickerOptions"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="2"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="9. Tuổi">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.tuoi"
                :disabled="true"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="10. Giới tính" prop="gioiTinh">
              <el-radio-group v-model="form.gioiTinh" style="width: 100%">
                <el-radio :label="1">Nam</el-radio>
                <el-radio :label="2">Nữ</el-radio>
              </el-radio-group>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="4"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="11. Nghề nghiệp">
              <el-select
                size="small"
                v-model="benhAn.benhNhan.ngheNghiep.maNn"
                placeholder="Tìm kiếm theo tên nghề nghiệp"
                clearable
                filterable
              >
                <el-option
                  v-for="(item, index) in ngheNghiepSelect"
                  :key="index"
                  :value="item.maNn"
                  :label="item.tenNn"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="4"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="12. Dân tộc">
              <el-select
                size="small"
                v-model="benhAn.benhNhan.danToc.maDanToc"
                placeholder="Tìm kiếm theo tên dân tộc"
                clearable
                filterable
              >
                <el-option
                  v-for="(item, index) in danTocSelect"
                  :key="index"
                  :value="item.maDanToc"
                  :label="item.tenDanToc"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="4"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="13. Ngoại kiều">
              <el-select
                size="small"
                v-model="benhAn.benhNhan.quocGia.maQg"
                placeholder="Tìm kiếm theo tên quốc gia"
                filterable
              >
                <el-option
                  v-for="(item, index) in ngoaiKieuSelect"
                  :key="index"
                  :value="item.maQg"
                  :label="item.tenQg"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="4"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="14. Tỉnh/Thành phố" prop="maTinh">
              <el-select
                size="small"
                v-model="form.maTinh"
                placeholder="Tìm kiếm theo tên tỉnh/thành phố"
                @change="changeTinh(form.maTinh)"
                filterable
              >
                <el-option
                  v-for="(item, index) in tinhThanhSelect"
                  :key="index"
                  :value="item.maTinh"
                  :label="item.tenTinh"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="4"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="15. Quận/Huyện" prop="maQh">
              <el-select
                size="small"
                v-model="form.maQh"
                placeholder="Tìm kiếm theo tên quận/huyện"
                @change="changeQuanHuyen(form.maQh)"
                filterable
              >
                <el-option
                  v-for="(item, index) in quanHuyenSelect"
                  :key="index"
                  :value="item.maQh"
                  :label="item.tenQh"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="4"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="16. Xã/Phường" prop="maPxa">
              <el-select
                size="small"
                v-model="form.maPxa"
                placeholder="Tìm kiếm theo tên xã/phường"
                filterable
              >
                <el-option
                  v-for="(item, index) in xaPhuongSelect"
                  :key="index"
                  :value="item.maPxa"
                  :label="item.tenPxa"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="4"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="17. Số nhà">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.soNha"
                placeholder="VD: số 13"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="4"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="18. Thôn/Phố">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.thon"
                placeholder="VD: phố Huế"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="6"
            lg="4"
            xl="4"
            class="padding-cols"
          >
            <el-form-item label="19. Nơi làm việc">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.noiLamViec"
                placeholder="Ghi đầy đủ địa chỉ"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="4"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="20. Đối tượng" prop="maDt">
              <el-select
                size="small"
                v-model="form.maDt"
                placeholder="Chọn một giá trị"
                clearable
                filterable
              >
                <el-option
                  v-for="(item, index) in doiTuongSelect"
                  :key="index"
                  :value="item.maDt"
                  :label="item.tenDt"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="21. Thẻ BHYT đến">
              <el-date-picker
                size="small"
                style="width: 100%"
                v-model="benhAn.benhNhan.gtbhytdn"
                placeholder="23/04/2022"
                format="dd/MM/yyyy"
                value-format="yyyy-MM-ddTHH:mm:ss"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="22. Số thể BHYT">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.soTheBhyt"
                placeholder="VD: 123456"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="6"
            lg="8"
            xl="8"
            class="padding-cols"
          >
            <el-form-item label="23. Họ tên, địa chỉ người nhà khi cần báo tin">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.lienHe"
                placeholder="VD: Vũ Thanh Hương, số 1, đường Thanh Bình,..."
              >
              </el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="4"
            class="padding-cols"
          >
            <el-form-item label="24. Số điện thoại">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.soDienThoai"
                placeholder="VD: 0979xxxxxx"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="25. Họ tên cha">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.hoTenCha"
                placeholder="VD: Nguyễn Văn A"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="26. Họ tên mẹ">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.hoTenMe"
                placeholder="VD: Nguyễn Thị B"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="27. Người giám hộ">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.nguoiGiamHo"
                placeholder="VD: Nguyễn Thị B"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="28. Quan hệ người giám hộ">
              <el-input
                size="small"
                placeholder="VD: Mẹ ruột"
                v-model="benhAn.benhNhan.quanHeNguoiGiamHo"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="29. CMND/ Hộ chiếu">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.cmnd"
                placeholder="VD: 0013xxxxxxxx"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="30. Cơ quan cấp">
              <el-input
                size="small"
                v-model="benhAn.benhNhan.noiCapCmnd"
                placeholder="Cơ quan cấp"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="31. Ngày cấp">
              <el-date-picker
                size="small"
                v-model="benhAn.benhNhan.ngayCapCmnd"
                style="width: 100%"
                placeholder="VD: 15/08/2018"
                :picker-options="pickerOptions"
                format="dd/MM/yyyy"
                value-format="yyyy-MM-ddTHH:mm:ss"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="32. Ngày giờ vào viện" prop="ngayVv">
              <el-date-picker
                size="small"
                v-model="form.ngayVv"
                type="datetime"
                style="width: 100%"
                format="dd/MM/yyyy HH:mm"
                value-format="yyyy-MM-ddTHH:mm:ss"
                placeholder="DD/MM/YYYY HH:mm"
                :picker-options="pickerOptions"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="33. Khoa vào viện" prop="maKhoa">
              <el-select
                size="small"
                v-model="form.maKhoa"
                placeholder="Tìm kiếm theo tên khoa"
                @change="changeKhoa(form.maKhoa)"
                filterable
                clearable
              >
                <el-option
                  v-for="(item, index) in khoaSelect"
                  :key="index"
                  :value="item.maKhoa"
                  :label="item.tenKhoa"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="34. Số buồng">
              <el-select
                size="small"
                v-model="benhAn.buong.maBuong"
                placeholder="Tìm kiếm theo tên buồng"
                @change="changeBuongKham(benhAn.buong.maBuong, form.maKhoa)"
                filterable
              >
                <el-option
                  v-for="(item, index) in soBuongSelect"
                  :key="index"
                  :label="item.tenBuong"
                  :value="item.maBuong"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="35. Số giường">
              <el-select
                size="small"
                v-model="benhAn.giuong.maGiuong"
                placeholder="Tìm kiếm theo số giường"
                :disabled="!benhAn.buong.maBuong"
                filterable
              >
                <el-option
                  v-for="(item, index) in soGiuongSelect"
                  :key="index"
                  :label="item.tenGiuong"
                  :value="item.maGiuong"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="12"
            sm="12"
            md="3"
            lg="4"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="36. Ngày giờ ra viện" prop="ngayRv">
              <el-date-picker
                size="small"
                v-model="form.ngayRv"
                type="datetime"
                style="width: 100%"
                placeholder="DD/MM/YYYY HH:mm:ss"
                format="dd/MM/yyyy HH:mm"
                value-format="yyyy-MM-ddTHH:mm:ss"
                :picker-options="pickerOptions"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <template v-if="edit">
            <v-col
              cols="12"
              xs="12"
              sm="12"
              md="3"
              lg="3"
              xl="3"
              class="padding-cols"
            >
              <el-form-item
                :disabled="false"
                label="Đã đóng bệnh án"
                prop="xacNhanKetThucHs"
              >
                <el-select size="small" v-model="form.xacNhanKetThucHs">
                  <el-option
                    v-for="(item, index) in [
                      {
                        value: 1,
                        label: 'Đã đóng',
                      },
                      {
                        value: 0,
                        label: 'Chưa đóng',
                      },
                    ]"
                    :key="index"
                    :value="item.value"
                    :label="item.label"
                  >
                  </el-option>
                </el-select>
              </el-form-item>
            </v-col>
            <v-col
              cols="12"
              xs="12"
              sm="12"
              md="3"
              lg="3"
              xl="3"
              class="padding-cols"
            >
              <el-form-item
                label="Người đóng"
                prop="nguoiXacNhanKetThucHs"
                style="width: 100%"
              >
                <base-select-async
                  v-model="form.nguoiXacNhanKetThucHs"
                  placeholder="Người đóng"
                  keyValue="maNv"
                  label="hoTen"
                  :apiFunc="getNhanVien"
                  style="width: 100%"
                  size="medium"
                ></base-select-async>
              </el-form-item>
            </v-col>
            <v-col
              cols="12"
              xs="12"
              sm="12"
              md="3"
              lg="3"
              xl="3"
              class="padding-cols"
            >
              <el-form-item
                label="Ngày đóng"
                prop="ngayXacNhanKetThucHs"
                style="width: 100%"
              >
                <el-date-picker
                  v-model="form.ngayXacNhanKetThucHs"
                  type="date"
                  placeholder="Ngày đóng"
                  style="width: 100%"
                  :format="'dd/MM/yyyy'"
                  :value-format="'yyyy-MM-dd'"
                >
                </el-date-picker>
              </el-form-item>
            </v-col>
            <v-col
              cols="12"
              xs="12"
              sm="12"
              md="3"
              lg="3"
              xl="3"
              class="padding-cols"
            >
              <el-form-item label="Hủy" prop="huy">
                <el-select size="small" v-model="form.huy">
                  <el-option
                    v-for="(item, index) in [
                      {
                        value: true,
                        label: 'Đã hủy',
                      },
                      {
                        value: false,
                        label: 'Chưa hủy',
                      },
                    ]"
                    :key="index"
                    :value="item.value"
                    :label="item.label"
                  >
                  </el-option>
                </el-select>
              </el-form-item>
            </v-col>
          </template>
        </v-row>
      </el-form>
    </div>
  </component>
</template>

<script>
// import { getBuongKham, getKhoa } from "@/api/phieu-kham-benh-vao-vien";
import {
  getLoaiBenhAn,
  getDetailBenhAn,
  updateThongTinChung,
  createBa,
  updateDongThongTinChung,
} from "@/api/benh-an.js";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import { getQuanHuyen, getTinhThanh, getXaPhuong } from "@/api/dia-gioi.js";
import * as apiDanToc from "@/api/dan-toc.js";
import * as apiKhoaGiuong from "@/api/khoa-giuong.js";
import * as apiKhoaBuong from "@/api/khoa-buong.js";
import * as apiKhoa from "@/api/khoa.js";
import * as apiQuocGia from "@/api/quoc-gia.js";
import { getDoiTuong } from "@/api/doi-tuong.js";
import { getNgheNghiep } from "@/api/nghe-nghiep.js";
export default {
  props: {
    id: { type: [Number, String] },
    edit: {
      type: Boolean,
      default: true,
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  data: (vm) => ({
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    getNhanVien,
    action: {
      modify: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/thongtinbenhan/modify"
      ),
      close: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/thongtinbenhan/close"
      ),
    },
    form: {
      maLoaiBa: null,
      soVaoVien: null,
      maBn: null,
      hoTen: null,
      ngaySinh: null,
      gioiTinh: null,
      maTinh: null,
      maQh: null,
      maPxa: null,
      maDt: null,
      ngayVv: null,
      maKhoa: null,
      ngayRv: null,
      maYt: null,
      xacNhanKetThucHs: 0,
      nguoiXacNhanKetThucHs: null,
      ngayXacNhanKetThucHs: null,
      huy: 0,
    },
    benhAn: {
      benhNhan: {
        quanHeNguoiGiamHo: null,
        cmnd: null,
        danToc: {
          maDanToc: null,
          tenDanToc: null,
        },
        doiTuong: {
          maDt: null,
          tenDt: null,
        },
        gioiTinh: null,
        ghtbhyt: null,
        hoTen: null,
        hoTenCha: null,
        hoTenme: null,
        idba: null,
        lienHe: null,
        maBn: null,
        ngayCapCmnd: null,
        ngaySinh: null,
        ngheNghiep: {
          maNn: null,
          tenNn: null,
        },
        nguoiGiamHo: null,
        noiCapCmnd: null,
        noiLamViec: null,
        phuongXa: {
          maPxa: null,
          tenPxa: null,
        },
        quanHuyen: {
          maQh: null,
          tenQh: null,
        },
        quocGia: {
          maQg: null,
          tenQg: null,
        },
        soDienThoai: null,
        soNha: null,
        soTheBhyt: null,
        thon: null,
        tinh: {
          maTinh: null,
          tenTinh: null,
        },
        tuoi: null,
      },
      buong: {
        maBuong: null,
        tenBuong: null,
      },
      giuong: {
        maGiuong: null,
        tenGiuong: null,
      },
      huy: null,
      idba: null,
      khoa: {
        maKhoa: null,
        tenKhoa: null,
      },
      loaiBenhAn: {
        maLoaiBa: null,
        tenLoaiba: null,
      },
      maBa: null,
      maBv: null,
      maYt: null,
      ngayRv: null,
      ngayVv: null,
      soLuutru: null,
      soVaoVien: null,
      tenBv: null,
      tenDvcq: null,
    },
    pickerOptions: {
      disabledDate(time) {
        return time.getTime() > Date.now();
      },
    },
    doiTuongSelect: [],
    phanLoaiBenhAn: [],
    tinhThanhSelect: [],
    quanHuyenSelect: [],
    xaPhuongSelect: [],
    khoaSelect: [],
    soBuongSelect: [],
    soGiuongSelect: [],
    ngheNghiepSelect: [],
    danTocSelect: [],
    ngoaiKieuSelect: [],
    rules: {
      maLoaiBa: [
        {
          required: true,
          message: "Phải chọn loại bệnh án",
          trigger: "change",
        },
      ],
      soVaoVien: [
        {
          required: true,
          message: "Số vào viện không được để trống",
          trigger: "blur",
        },
      ],
      maBn: [
        {
          required: true,
          message: "Mã người bệnh không được để trống",
          trigger: "blur",
        },
      ],
      maYt: [
        {
          required: true,
          message: "Mã y tế không thể bỏ trống",
          trigger: "blur",
        },
      ],
      hoTen: [
        {
          required: true,
          message: "Họ tên người bệnh không được để trống",
          trigger: "blur",
        },
      ],
      ngaySinh: [
        {
          // type: "date",
          required: true,
          message: "Ngày sinh không được để trống",
          trigger: "change",
        },
      ],
      gioiTinh: [
        { required: true, message: "Phải chọn giới tính", trigger: "change" },
      ],
      maTinh: [
        {
          required: true,
          message: "Phải chọn tỉnh/thành phố",
          trigger: "change",
        },
      ],
      maQh: [
        { required: true, message: "Phải chọn quận/huyện", trigger: "change" },
      ],
      maPxa: [
        { required: true, message: "Phải chọn xã/phường", trigger: "change" },
      ],
      maDt: [
        { required: true, message: "Phải chọn đối tượng", trigger: "change" },
      ],
      maKhoa: [
        { required: true, message: "Phải chọn khoa", trigger: "change" },
      ],
      ngayVv: [
        {
          // type: "date",
          required: true,
          message: "Ngày vào viện không được để trống",
          trigger: "change",
        },
      ],
      ngayRv: [
        {
          // type: "date",
          required: true,
          message: "Ngày ra viện không được để trống",
          trigger: "change",
        },
      ],
    },
  }),
  created() {
    if (this.edit) this.getData();
    this.getSelectKhoa();
    this.getPhanLoai();
    this.getTinhThanhSelect();
    this.getNgheNghiepSelect();
    this.getNgoaiKieuSelect();
    this.getDanTocSelect();
    this.getDoiTuongSelect();
    this.randomMaBA();
    window.addEventListener("keydown", this.handlerKeyPress, false);
  },
  watch: {
    "form.ngaySinh": function (val) {
      let nam = new Date().getFullYear();
      if (val) {
        let namSinh = new Date(val).getFullYear();
        this.benhAn.benhNhan.tuoi = nam - namSinh;
      } else {
        this.benhAn.benhNhan.tuoi = null;
      }
    },
  },
  methods: {
    handlerKeyPress(e) {
      if(e.key == 'F10'){
        location.href = `${window.origin}/HSBADS/Index`;
        e.preventDefault();
      }
    },
    exit() {
      location.href = `${window.origin}/HSBADS/Index`;
    },
    randomMaBA() {
      if (!this.edit) {
        let year = new Date().getFullYear().toString().substring(2);
        let number = "";
        for (let i = 0; i < 10; i++) {
          number = number + Math.floor(Math.random() * 10).toString();
        }
        this.benhAn.maBa = `${year}BA${number}`;
      }
    },
    async getDoiTuongSelect() {
      let data = await getDoiTuong();
      this.doiTuongSelect = data.data;
    },
    async getData() {
      let data = await getDetailBenhAn(this.id);
      this.benhAn = data.data;
      if(data.data.benhNhan.tinh.maTinh){
        this.getQuanHuyenSelect(data.data.benhNhan.tinh.maTinh);
      }
      if(data.data.benhNhan.quanHuyen.maQh){
        this.getXaPhuongSelect(data.data.benhNhan.quanHuyen.maQh);
      }
      if(data.data.khoa.maKhoa){
        this.getBuongKhamBenh(data.data.khoa.maKhoa);
      }
      if(data.data.buong.maBuong&& data.data.khoa.maKhoa){
        this.getGiuongBenh(data.data.buong.maBuong, data.data.khoa.maKhoa);
      }
      this.form.maLoaiBa = this.benhAn.loaiBenhAn.maLoaiBa;
      this.form.soVaoVien = this.benhAn.soVaoVien;
      this.form.maBn = this.benhAn.benhNhan.maBn;
      this.form.hoTen = this.benhAn.benhNhan.hoTen;
      this.form.ngaySinh = this.benhAn.benhNhan.ngaySinh;
      this.form.gioiTinh = this.benhAn.benhNhan.gioiTinh;
      this.form.maTinh = this.benhAn.benhNhan.tinh.maTinh;
      this.form.maQh = this.benhAn.benhNhan.quanHuyen.maQh;
      this.form.maPxa = this.benhAn.benhNhan.phuongXa.maPxa;
      this.form.maDt = this.benhAn.benhNhan.doiTuong.maDt;
      this.form.ngayVv = this.benhAn.ngayVv;
      this.form.maKhoa = this.benhAn.khoa.maKhoa;
      this.form.ngayRv = this.benhAn.ngayRv;
      this.form.maYt = this.benhAn.maYt;
      this.form.xacNhanKetThucHs = this.benhAn.xacNhanKetThucHs;
      this.form.ngayXacNhanKetThucHs = this.benhAn.ngayXacNhanKetThucHs;
      this.form.nguoiXacNhanKetThucHs = this.benhAn.nguoiXacNhanKetThucHs;
      this.form.huy = this.benhAn.huy;
    },
    async getPhanLoai() {
      let data = await getLoaiBenhAn();
      this.phanLoaiBenhAn = data.data;
    },
    async getDanTocSelect() {
      let data = await apiDanToc.index();
      this.danTocSelect = data.data;
    },
    async getNgoaiKieuSelect() {
      let data = await apiQuocGia.index();
      this.ngoaiKieuSelect = data.data;
    },
    async getTinhThanhSelect() {
      let data = await getTinhThanh();
      this.tinhThanhSelect = data.data;
    },
    async getQuanHuyenSelect(maTinh = null) {
      let data = await getQuanHuyen({
        MaTinh: maTinh,
      });
      this.quanHuyenSelect = data.data;
    },
    async getXaPhuongSelect(MaQh = null) {
      let data = await getXaPhuong({
        MaQuanHuyen: MaQh,
      });
      this.xaPhuongSelect = data.data;
    },
    async getSelectKhoa() {
      let data = await apiKhoa.index();
      this.khoaSelect = data.data;
    },
    async getBuongKhamBenh(maKhoa) {
      if (!maKhoa) return;
      let data = await apiKhoaBuong.index({
        MaKhoa: maKhoa,
      });
      this.soBuongSelect = data.data;
    },
    async getGiuongBenh(maBuong, maKhoa) {
      if (!maBuong || !maKhoa) return;
      let data = await apiKhoaGiuong.index({
        MaBuong: maBuong,
        MaKhoa: maKhoa,
      });
      this.soGiuongSelect = data.data;
    },
    async getNgheNghiepSelect() {
      let data = await getNgheNghiep();
      this.ngheNghiepSelect = data.data;
    },
    changeTinh(maTinh) {
      this.form.maPxa = null;
      this.form.maQh = null;
      this.getQuanHuyenSelect(maTinh);
    },
    changeQuanHuyen(maQh) {
      this.form.maPxa = null;
      this.getXaPhuongSelect(maQh);
    },
    changeKhoa(maKhoa) {
      this.benhAn.buong = {
        maBuong: null,
        tenBuong: null,
      };
      this.benhAn.giuong = {
        maGiuong: null,
        tenGiuong: null,
      };
      this.getBuongKhamBenh(maKhoa);
    },
    changeBuongKham(maBuong, maKhoa) {
      this.benhAn.giuong = {
        maGiuong: null,
        tenGiuong: null,
      };
      this.getGiuongBenh(maBuong, maKhoa);
    },
    submit(formName, dongBenhAn = false) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          if (this.edit) {
            this.updateData(dongBenhAn);
          } else {
            this.createData();
          }
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    async createData() {
      this.benhAn.loaiBenhAn.maLoaiBa = this.form.maLoaiBa;
      this.benhAn.soVaoVien = this.form.soVaoVien;
      this.benhAn.benhNhan.maBn = this.form.maBn;
      this.benhAn.benhNhan.hoTen = this.form.hoTen;
      this.benhAn.benhNhan.ngaySinh = this.form.ngaySinh;
      this.benhAn.benhNhan.gioiTinh = this.form.gioiTinh;
      this.benhAn.benhNhan.tinh.maTinh = this.form.maTinh;
      this.benhAn.benhNhan.quanHuyen.maQh = this.form.maQh;
      this.benhAn.benhNhan.phuongXa.maPxa = this.form.maPxa;
      this.benhAn.benhNhan.doiTuong.maDt = this.form.maDt;
      this.benhAn.ngayVv = this.form.ngayVv;
      this.benhAn.khoa.maKhoa = this.form.maKhoa;
      this.benhAn.ngayRv = this.form.ngayRv;
      this.benhAn.maYt = this.form.maYt;
      try {
        await createBa(this.benhAn);
        this.$message({
          message: "Thêm mới thành công.",
          type: "success",
        });
        window.location.href = `/HSBADS/Index`;
        this.$emit("on-done");
      } catch (error) {
        console.log(error);
        this.$message.error("Thêm mới thất bại");
      }
    },
    async updateData(dongBenhAn = false) {
      if (dongBenhAn) {
        if (
          this.form.xacNhanKetThucHs &&
          (!this.form.nguoiXacNhanKetThucHs || !this.form.ngayXacNhanKetThucHs)
        ) {
          this.$message.error(
            "Người đóng bệnh án và ngày đóng không được để trống"
          );
          return;
        }
        this.benhAn.xacNhanKetThucHs = this.form.xacNhanKetThucHs;
        this.benhAn.nguoiXacNhanKetThucHs = this.form.nguoiXacNhanKetThucHs;
        this.benhAn.ngayXacNhanKetThucHs = this.form.ngayXacNhanKetThucHs;
        this.benhAn.maYt = this.benhAn.maYt || "";
      } else {
        this.benhAn.loaiBenhAn.maLoaiBa = this.form.maLoaiBa;
        this.benhAn.soVaoVien = this.form.soVaoVien;
        this.benhAn.benhNhan.maBn = this.form.maBn;
        this.benhAn.benhNhan.hoTen = this.form.hoTen;
        this.benhAn.benhNhan.ngaySinh = this.form.ngaySinh;
        this.benhAn.benhNhan.gioiTinh = this.form.gioiTinh;
        this.benhAn.benhNhan.tinh.maTinh = this.form.maTinh;
        this.benhAn.benhNhan.quanHuyen.maQh = this.form.maQh;
        this.benhAn.benhNhan.phuongXa.maPxa = this.form.maPxa;
        this.benhAn.benhNhan.doiTuong.maDt = this.form.maDt;
        this.benhAn.ngayVv = this.form.ngayVv;
        this.benhAn.khoa.maKhoa = this.form.maKhoa;
        this.benhAn.ngayRv = this.form.ngayRv;
        this.benhAn.maYt = this.form.maYt;
        this.benhAn.huy = this.form.huy;
      }
      try {
        if (dongBenhAn) {
          await updateDongThongTinChung(this.id, this.benhAn);
        } else {
          await updateThongTinChung(this.id, this.benhAn);
        }
        this.$message({
          message: "Cập nhật thành công.",
          type: "success",
        });
        this.getData();
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

<style>
.el-select {
  width: 100%;
}

.red-dot {
  color: red;
}

.padding-cols {
  padding-bottom: 3px !important;
  padding-top: 3px !important;
}

.thong-tin-benh-an-chung label {
  margin-bottom: -5px !important;
}

.el-form-item {
  margin-bottom: 0px !important;
}

.el-form-item__label {
  font-size: 13px;
}

.el-form-item__content {
  line-height: 35px;
}
</style>
