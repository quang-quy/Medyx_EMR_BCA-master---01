<template>
  <app-wrapper :idba="id">
    <div class="ma-5">
      <div class="d-flex justify-space-between align-flex-end mb-3">
        <div class="d-flex">
          <v-btn fab small color="primary" depressed outlined @click="goBack()">
            <v-icon dark> mdi-arrow-left </v-icon>
          </v-btn>
          <div class="ml-3">
            <div style="font-size: 20px; font-weight: bold">
              {{
                edit
                  ? "Cập nhật phiếu theo dõi chăm sóc bệnh nhân"
                  : "Thêm mới phiếu theo dõi chăm sóc bệnh nhân"
              }}
            </div>
            <i
              >(<span style="color: red; font-weight: bold">*</span>) : Mục bắt
              buộc</i
            >
          </div>
        </div>
        <div>
          <div class="d-flex">
            <v-btn
              color="primary"
              @click="submit('form')"
              small
              :disabled="edit ? disableActions.create : disableActions.modify"
            >
              <v-icon small left> mdi-pencil </v-icon
              >{{ edit ? "Cập nhật" : "Thêm mới" }}
            </v-btn>
          </div>
        </div>
      </div>
      <v-progress-linear
        color="primary"
        rounded
        value="100"
        height="2"
      ></v-progress-linear>
      <el-form :model="form" :rules="rules" ref="form" class="px-2">
        <v-row class="mt-0">
          <v-col v-if="edit" cols="12">
            <el-checkbox
              v-model="form.huy"
              :disabled="disableActions.modify || form.idhis"
              >Đã hủy</el-checkbox
            >
          </v-col>
          <v-col xl="3" lg="4" md="6" class="padding-cols">
            <el-form-item
              label="Bệnh khoa điều trị (Mã bệnh - tên bệnh)"
              prop="maBenh"
            >
              <el-input size="small" v-model="form.maBenh" disabled></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="6" class="padding-cols">
            <el-form-item label="Chẩn đoán">
              <base-select-async
                placeholder="Tìm kiếm theo mã bệnh"
                v-model="form.chanDoan"
                :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                keyValue="tenBenh"
                :apiFunc="getBenhTat"
                style="width: 100%"
                size="small"
              ></base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Khoa chăm sóc">
              <base-select-async
                v-model="form.sttkhoa"
                placeholder="Tìm kiếm theo stt khoa điều trị"
                @get-item="getItemKhoaChamSoc"
                :label="(item) => `${item.maKhoa} - ${item.khoa.tenKhoa}`"
                keyValue="stt"
                :apiFunc="getKhoaDieuTri"
                style="width: 100%"
                size="small"
              ></base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày vào khoa">
              <el-date-picker
                size="small"
                style="width: 100%"
                v-model="ngayVaoKhoa"
                type="datetime"
                disabled
                format="dd/MM/yyyy HH:mm"
                value-format="yyyy-MM-ddTHH:mm:ss"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>

          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày bắt đầu chăm sóc">
              <el-date-picker
                type="datetime"
                value-format="yyyy-MM-ddTHH:mm:ss"
                format="dd/MM/yyyy HH:mm"
                v-model="form.ngayChamSocBd"
                size="small"
                style="width: 100%"
              ></el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày kết thúc chăm sóc">
              <el-date-picker
                type="datetime"
                value-format="yyyy-MM-ddTHH:mm:ss"
                format="dd/MM/yyyy HH:mm"
                v-model="form.ngayChamSocKt"
                size="small"
                style="width: 100%"
              ></el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày chăm sóc thứ">
              <el-input-number
                style="width: 100%"
                v-model="form.ngayChamSocLan"
                :min="1"
                size="small"
              >
              </el-input-number>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày giờ chăm sóc" prop="ngayChamSoc">
              <el-date-picker
                type="datetime"
                value-format="yyyy-MM-ddTHH:mm:ss"
                format="dd/MM/yyyy HH:mm"
                v-model="form.ngayChamSoc"
                size="small"
                style="width: 100%"
              ></el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Điều dưỡng chăm sóc" prop="dieuDuong">
              <base-select-async
                placeholder="Tìm kiếm theo tên"
                v-model="form.dieuDuong"
                :label="(item) => `${item.hoTen}`"
                keyValue="maNv"
                :apiFunc="getNhanVien"
                style="width: 100%"
                size="small"
              ></base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Dị ứng">
              <el-radio-group style="width: 100%" v-model="form.diUng">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="4" md="4" class="padding-cols">
            <el-form-item label="Dị ứng với">
              <el-input size="small" v-model="form.diUngMota"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Thuốc">
              <el-input size="small" v-model="form.thuoc"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="6" md="6" class="padding-cols">
            <el-form-item label="Tiền sử gia đình">
              <br />
              <el-checkbox
                size="small"
                @change="setModelCheckBox"
                v-for="(item, index) in checkBoxData.tienSuGiaDinh"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Cấp chăm sóc">
              <el-select
                size="small"
                style="width: 100%"
                v-model="form.capCs"
                @change="changeCapCs"
              >
                <el-option
                  v-for="item in checkBoxData.CapCS"
                  :key="item.ma"
                  :label="item.ten"
                  :value="item.ma"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" class="padding-cols">
            <el-form-item label="Mạch (nhịp/phút)">
              <el-input
                size="small"
                type="number"
                controls-position="right"
                v-model="form.mach"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" class="padding-cols">
            <el-form-item label="Nhiệt độ (℃)" prop="nhietDo">
              <el-input
                size="small"
                v-model="form.nhietDo"
                type="number"
                step="0.1"
                controls-position="right"
              >
              </el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="3" md="3" class="padding-cols">
            <el-form-item label="Huyết áp (mmHg)">
              <el-input size="small" v-model="form.huyetAp"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="3" md="3" class="padding-cols">
            <el-form-item label="Cân nặng (Kg)">
              <el-input
                size="small"
                type="number"
                :min="0"
                controls-position="right"
                step="0.1"
                v-model="form.canNang"
              >
              </el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="3" md="3" class="padding-cols">
            <el-form-item label="Nhịp thở (lần/phút)">
              <el-input
                size="small"
                type="number"
                controls-position="right"
                v-model="form.nhipTho"
              >
              </el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="3" md="3" class="padding-cols">
            <el-form-item label="SpO2">
              <el-input
                size="small"
                type="number"
                controls-position="right"
                step="0.1"
                v-model="form.spO2"
              ></el-input>
            </el-form-item>
          </v-col>

          <v-col xl="12" lg="12" md="12" class="padding-cols">
            <el-form-item label="Ý thức">
              <br />
              <div v-if="capChamSoc == MA_CAP_I">
                <el-checkbox
                  class="width-checkbox"
                  @change="setModelCheckBox"
                  size="small"
                  v-for="(item, index) in checkBoxData.YThucCSCapI"
                  :key="index"
                  v-model="item.checkbox"
                >
                  {{ item.ten }}
                </el-checkbox>
              </div>
              <div v-else>
                <el-checkbox
                  class="width-checkbox"
                  @change="setModelCheckBox"
                  size="small"
                  v-for="(item, index) in checkBoxData.YThucCSCapII"
                  :key="index"
                  v-model="item.checkbox"
                >
                  {{ item.ten }}
                </el-checkbox>
              </div>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Thể trạng">
              <br />
              <div v-if="capChamSoc == MA_CAP_I">
                <el-checkbox
                  class="width-checkbox"
                  @change="setModelCheckBox"
                  size="small"
                  v-for="(item, index) in checkBoxData.TheTrangCSCapI"
                  :key="index"
                  v-model="item.checkbox"
                >
                  {{ item.ten }}
                </el-checkbox>
              </div>
              <div v-else>
                <el-checkbox
                  class="width-checkbox"
                  @change="setModelCheckBox"
                  size="small"
                  v-for="(item, index) in checkBoxData.TheTrangCSCapII"
                  :key="index"
                  v-model="item.checkbox"
                >
                  {{ item.ten }}
                </el-checkbox>
              </div>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Thể trạng-chiều cao">
              <el-input
                type="number"
                size="small"
                :min="0"
                :step="0.01"
                v-model="form.chieuCao"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="4" class="padding-cols">
            <el-form-item label="Phù">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.phu"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="4" class="padding-cols">
            <el-form-item label="Vị trí phù">
              <el-input size="small" v-model="form.phuVitri"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="4" class="padding-cols">
            <el-form-item label="Tính chất phù">
              <el-input size="small" v-model="form.phuTinhChat"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Da niêm mạc">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.DaNiemMac"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="2" md="2" class="padding-cols">
            <el-form-item label="Tuần hoàn">
              <el-select
                size="small"
                style="width: 100%"
                v-model="form.tuanHoan"
              >
                <el-option
                  v-for="item in checkBoxData.TuanHoanCS"
                  :key="item.ma"
                  :label="item.ten"
                  :value="item.ma"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="4" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tính chất đau ngực">
              <el-input
                size="small"
                v-model="form.tuanHoanTchatDauNguc"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Hô hấp">
              <br />
              <div v-if="capChamSoc == MA_CAP_I">
                <el-checkbox
                  class="width-checkbox"
                  @change="setModelCheckBox"
                  size="small"
                  v-for="(item, index) in checkBoxData.HoHapCSCapI"
                  :key="index"
                  v-model="item.checkbox"
                >
                  {{ item.ten }}
                </el-checkbox>
              </div>
              <div v-else>
                <el-checkbox
                  class="width-checkbox"
                  @change="setModelCheckBox"
                  size="small"
                  v-for="(item, index) in checkBoxData.HoHapCSCapII"
                  :key="index"
                  v-model="item.checkbox"
                >
                  {{ item.ten }}
                </el-checkbox>
              </div>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="2" md="2" class="padding-cols">
            <el-form-item label="Thở oxi">
              <el-input
                size="small"
                type="number"
                :min="0"
                v-model="form.hoHapSloxy"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="2" md="2" class="padding-cols">
            <el-form-item label="Tính chất đờm">
              <el-input size="small" v-model="form.hoHapTchatDom"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="2" md="2" class="padding-cols">
            <el-form-item label="Dẫn lưu">
              <el-input size="small" v-model="form.hoHapDanLuu"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Tiêu hóa">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.TieuHoa"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Vị trí đau bụng">
              <el-input
                size="small"
                v-model="form.tieuHoaVitriDauBung"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Đại tiện">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.DaiTien"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="3" class="padding-cols">
            <el-form-item label="Đại tiện-số lần">
              <el-input
                size="small"
                type="number"
                :min="0"
                v-model="form.tieuTienSoLuong"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="3" md="3" class="padding-cols">
            <el-form-item label="Đại tiện-màu sắc">
              <el-input size="small" v-model="form.tieuTienMauSac"></el-input>
            </el-form-item>
          </v-col>
          <v-col
            v-if="capChamSoc == MA_CAP_I"
            xl="6"
            lg="12"
            md="12"
            class="padding-cols"
          >
            <el-form-item label="Thận, tiết niệu">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.TietNieuCSCapI"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col
            v-if="capChamSoc == MA_CAP_II || capChamSoc == MA_CAP_III"
            xl="12"
            lg="12"
            md="12"
            class="padding-cols"
          >
            <el-form-item label="Thận, tiết niệu">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.TietNieuCSCapII"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col
            v-if="capChamSoc == MA_CAP_I"
            xl="6"
            lg="12"
            md="12"
            class="padding-cols"
          >
            <el-form-item label="Tiểu tiện">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.TieuTienCSCapI"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="4" md="6" class="padding-cols">
            <el-form-item label="Tâm, thần kinh bình thường">
              <el-radio-group
                size="small"
                style="width: 100%"
                v-model="form.tamThanKinh"
              >
                <el-radio :label="'1'">Bình thường</el-radio>
                <el-radio :label="'2'">Khác</el-radio>
              </el-radio-group>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="6" class="padding-cols">
            <el-form-item label="Tâm, thần kinh khác">
              <el-input size="small" v-model="form.tamThanKinhKhac"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="12" class="padding-cols">
            <el-form-item label="Tâm lý người bệnh">
              <el-radio-group
                size="small"
                style="width: 100%"
                v-model="form.tamLyNguoiBenh"
              >
                <el-radio :label="'1'">Lo lắng</el-radio>
                <el-radio :label="'2'">Không lo lắng</el-radio>
                <el-radio :label="'3'">Không biết</el-radio>
              </el-radio-group>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="12" class="padding-cols">
            <el-form-item label="Ngủ">
              <br />
              <el-checkbox
                class="width-checkbox"
                size="small"
                v-for="(item, index) in checkBoxData.NguCS"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="2" md="4" class="padding-cols">
            <el-form-item label="Thời gian ngủ">
              <el-input
                size="small"
                type="number"
                :min="0"
                :max="24"
                v-model="form.nguThoiGian"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="2" md="4" class="padding-cols">
            <el-form-item label="Vận động">
              <el-select
                size="small"
                style="width: 100%"
                v-model="form.VanDong"
              >
                <el-option
                  v-for="item in checkBoxData.VanDong"
                  :key="item.ma"
                  :label="item.ten"
                  :value="item.ma"
                >
                </el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="2" md="4" class="padding-cols">
            <el-form-item label="Vận động - tính chất liệt">
              <el-input size="small" v-model="form.vanDongTchatLiet"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="12" md="12" class="padding-cols">
            <el-form-item label="Cơ, xương, khớp">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.CoXuongKhopCS"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Vết thương/Mổ-vị trí">
              <el-input size="small" v-model="form.vetThuongViTri"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Vết thương/Mổ">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.VetThuong"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="6" md="6" class="padding-cols">
            <el-form-item label="Vết thương/Mổ-khác">
              <el-input size="small" v-model="form.vetThuongKhac"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="6" md="6" class="padding-cols">
            <el-form-item label="Dẫn lưu - mô tả">
              <el-input
                size="small"
                v-model="form.vetThuongMotaDanLuu"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="12" md="12" class="padding-cols">
            <el-form-item label="Dẫn lưu">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.DanLuu"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Chân dẫn lưu">
              <el-input
                size="small"
                v-model="form.vetThuongChanDanLuu"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Nhận định khác">
              <el-input size="small" v-model="form.nhanDinhKhac"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="4" md="4" class="padding-cols">
            <el-form-item label="Chẩn đoán chăm sóc">
              <el-input size="small" v-model="form.chanDoanChamSoc"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Hướng dẫn nội quy, thủ tục nhập viện">
              <el-radio-group
                style="width: 100%"
                size="small"
                v-model="form.huongDanNoiQuy"
              >
                <el-radio :label="'1'">Có</el-radio>
                <el-radio :label="'2'">Không</el-radio>
              </el-radio-group>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Theo dõi dấu hiệu sinh tồn">
              <el-radio-group
                style="width: 100%"
                size="small"
                v-model="form.theoDoiDhst"
              >
                <el-radio :label="'1'">Có</el-radio>
                <el-radio :label="'2'">Không</el-radio>
              </el-radio-group>
            </el-form-item>
          </v-col>
          <v-col
            v-if="capChamSoc == MA_CAP_I"
            xl="6"
            lg="4"
            md="4"
            class="padding-cols"
          >
            <el-form-item label="Vệ sinh thân thể">
              <br />
              <el-checkbox
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.VeSinhThanThe"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="12" md="12" class="padding-cols">
            <el-form-item label="Thực hiện y lệnh">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.ThucHienYLenh"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="12" lg="12" md="12" class="padding-cols">
            <el-form-item label="Thủ thuật tây y">
              <br />
              <div v-if="capChamSoc == MA_CAP_I">
                <el-checkbox
                  class="width-checkbox-long"
                  size="small"
                  @change="setModelCheckBox"
                  v-for="(item, index) in checkBoxData.ThuThuat_TayYCSCapI"
                  :key="index"
                  v-model="item.checkbox"
                >
                  {{ item.ten }}
                </el-checkbox>
              </div>
              <div v-else>
                <el-checkbox
                  class="width-checkbox-long"
                  size="small"
                  @change="setModelCheckBox"
                  v-for="(item, index) in checkBoxData.ThuThuat_TayYCSCapII"
                  :key="index"
                  v-model="item.checkbox"
                >
                  {{ item.ten }}
                </el-checkbox>
              </div>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Giờ truyền dịch">
              <el-date-picker
                type="datetime"
                size="small"
                format="dd/MM/yyyy HH:mm"
                style="width: 100%"
                v-model="form.gioTruyenDichBd"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Giờ kết thúc truyền dịch">
              <el-date-picker
                type="datetime"
                size="small"
                format="dd/MM/yyyy HH:mm"
                style="width: 100%"
                v-model="form.gioTruyenDichKt"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Khí dung - tần số (lần/phút)">
              <el-input
                type="number"
                size="small"
                v-model="form.khiDungTanSo"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Thời gian test đường huyết mao mạch">
              <el-date-picker
                type="datetime"
                size="small"
                format="dd/MM/yyyy HH:mm"
                style="width: 100%"
                v-model="form.testDhmmGio"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="12" lg="12" md="12" class="padding-cols">
            <el-form-item label="Thủ thuật - đông y">
              <br />
              <el-checkbox
                class="width-checkbox-long"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.ThuThuat_DYCS"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Test đường huyết mao mạch">
              <el-input
                type="number"
                size="small"
                v-model="form.testDhmmSoLan"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Thủ thuật đông y - vltl">
              <el-input size="small" v-model="form.thuThuatDyVltl"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="4" md="4" class="padding-cols">
            <el-form-item label="Thủ thuật đông y - ngâm thuốc">
              <el-input size="small" v-model="form.thuThuatDyThuoc"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="12" md="12" class="padding-cols">
            <el-form-item label="Thủ thuật - thay băng">
              <br />
              <div v-if="capChamSoc == MA_CAP_I">
                <el-checkbox
                  class="width-checkbox-long"
                  size="small"
                  @change="setModelCheckBox"
                  v-for="(item, index) in checkBoxData.ThayBangCSCapI"
                  :key="index"
                  v-model="item.checkbox"
                >
                  {{ item.ten }}
                </el-checkbox>
              </div>
              <div v-else>
                <el-checkbox
                  class="width-checkbox-long"
                  size="small"
                  @change="setModelCheckBox"
                  v-for="(item, index) in checkBoxData.ThayBangCSCapII"
                  :key="index"
                  v-model="item.checkbox"
                >
                  {{ item.ten }}
                </el-checkbox>
              </div>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="6" md="6" class="padding-cols">
            <el-form-item
              label="Thủ thuật - vị trí thay băng"
              prop="thayBangViTriThay"
            >
              <el-input
                size="small"
                v-model="form.thayBangViTriThay"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="6" md="6" class="padding-cols">
            <el-form-item label="Vệ sinh cá nhân">
              <br />
              <el-checkbox
                class="width-checkbox"
                size="small"
                @change="setModelCheckBox"
                v-for="(item, index) in checkBoxData.VeSinhCaNhan"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="12" lg="12" md="12" class="padding-cols">
            <el-form-item label="Dinh dưỡng">
              <br />
              <el-checkbox
                class="width-checkbox"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.DinhDuongCS"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="12" lg="12" md="12" class="padding-cols">
            <el-form-item label="GDSK">
              <br />
              <el-checkbox
                class="width-checkbox-long"
                @change="setModelCheckBox"
                size="small"
                v-for="(item, index) in checkBoxData.GDSK"
                :key="index"
                v-model="item.checkbox"
              >
                {{ item.ten }}
              </el-checkbox>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Thực hiện y lệnh khác">
              <el-input
                type="textarea"
                :rows="2"
                size="small"
                v-model="form.thucHienYlenhKhac"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="6" lg="6" md="6" class="padding-cols">
            <el-form-item label="Xử trí">
              <el-input
                type="textarea"
                :rows="2"
                size="small"
                v-model="form.xuTri"
              ></el-input>
            </el-form-item>
          </v-col>
        </v-row>
        <v-row v-if="edit">
          <v-col cols="12" class="pt-4">
            <div style="height: 450px; border: 1px solid #d5dbdb" class="pa-3">
              <div style="font-size: 14px; font-weight: bold">
                <v-icon>mdi-attachment</v-icon>
                Tệp đính kèm
              </div>
              <div>
                <div class="mt-4">
                  <input
                    name="file"
                    ref="upload-image"
                    style="display: none"
                    type="file"
                    :multiple="!edit"
                    @change="handleUpload($event)"
                  />
                  <v-tooltip
                    bottom
                    v-if="tienTrinhUpload == 0 || tienTrinhUpload == 100"
                  >
                    <template v-slot:activator="{ on, attrs }">
                      <div
                        class="box-file d-flex align-center justify-center flex-column"
                        v-bind="attrs"
                        v-on="on"
                        @click="clickUpload"
                        v-if="!loading"
                      >
                        <v-icon large color="#8c939d"> mdi-upload </v-icon>
                        <div style="font-size: 12px" class="mt-1">
                          Tải lên tập tin
                        </div>
                      </div>
                      <div
                        class="box-file d-flex align-center justify-center mr-6 ml-2"
                        v-bind="attrs"
                        v-on="on"
                        v-else
                      >
                        <v-progress-circular
                          :rotate="-90"
                          :size="50"
                          :width="15"
                          :value="tienTrinhUpload"
                          color="primary"
                        >
                          {{ tienTrinhUpload }}
                        </v-progress-circular>
                      </div>
                    </template>
                    <span>{{
                      !loading ? "Thêm tập tin" : "Đang tải lên..."
                    }}</span>
                  </v-tooltip>
                </div>
                <div>
                  <div class="mb-2 mt-4">Danh sách file phi cấu trúc:</div>
                  <div
                    v-if="files && files.length > 0"
                    style="height: 250px; overflow-y: scroll"
                  >
                    <div
                      v-for="(item, index) in files"
                      :key="index"
                      class="pl-3"
                    >
                      <div class="files" v-if="!item.huy">
                        <div class="d-flex align-center">
                          <div>{{ index + 1 }}</div>
                          <v-icon small class="mr-3 ml-3">mdi-file</v-icon>
                          <div
                            style="
                              width: 250px;
                              overflow: hidden;
                              font-size: 13px;
                            "
                          >
                            {{ item.name }}
                          </div>
                        </div>
                        <div class="d-flex align-center">
                          <v-tooltip bottom class="mr-4">
                            <template v-slot:activator="{ on, attrs }">
                              <i
                                style="padding-right: 10px"
                                color="rgba(0, 0, 0, 0.54)"
                                dark
                                v-bind="attrs"
                                v-on="on"
                                @click="
                                  getDownloadFile(
                                    item.idba,
                                    item.stt,
                                    item.name
                                  )
                                "
                                class="el-icon-download"
                              >
                              </i>
                            </template>
                            <span>Tải xuống</span>
                          </v-tooltip>
                          <v-tooltip bottom class="mr-4">
                            <template v-slot:activator="{ on, attrs }">
                              <template>
                                <el-popconfirm
                                  title="Bạn có chắc muốn xóa không?"
                                  @confirm="removeFile(index, item)"
                                >
                                  <i
                                    slot="reference"
                                    size="medium"
                                    class="el-icon-close"
                                  >
                                  </i>
                                </el-popconfirm>
                              </template>
                            </template>
                            <span>Hủy</span>
                          </v-tooltip>
                        </div>
                      </div>
                      <div class="files d-flex" v-else>
                        <div class="d-flex align-center" style="flex: 1">
                          <div>{{ index + 1 }}</div>
                          <v-icon class="mr-3 ml-3" small>mdi-file</v-icon>
                          <div
                            style="
                              max-width: 250px;
                              overflow: hidden;
                              text-decoration: line-through;
                            "
                          >
                            {{ item.name }}
                          </div>
                        </div>
                        <div>
                          <v-chip
                            class="ma-2"
                            color="red"
                            text-color="white"
                            small
                          >
                            Đã hủy
                          </v-chip>
                        </div>
                      </div>
                      <div
                        style="
                          border-bottom: 0.5px solid #d9d9d9;
                          width: 100%;
                          height: 0px;
                        "
                      ></div>
                    </div>
                  </div>
                  <div
                    v-else
                    style="height: 160px"
                    class="d-flex align-center justify-center"
                  >
                    <div>
                      <v-icon
                        large
                        color="#8c939d"
                        class="d-flex align-center justify-center mb-2"
                      >
                        mdi-file-find</v-icon
                      >
                      <div style="font-size: 12px">Không có tệp đính kèm</div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </v-col>
        </v-row>
      </el-form>
    </div>
  </app-wrapper>
</template>
<script>
import * as apiNhanVien from "@/api/nhan-vien.js";
import * as apiKhoa from "@/api/khoa.js";
import * as apiKhoaDT from "@/api/khoa-dieu-tri.js";
import * as apiBenhTat from "@/api/benh-tat";
import {
  form,
  dataChecBox,
  danhMucCheckBox,
  dataCheckBoxAsyn,
  MA_CAP_I,
  MA_CAP_II,
  MA_CAP_III,
} from "./helperData.js";
import { getSelectBox } from "@/api/danh-muc.js";
import * as apiChamSoc from "@/api/benh-an-phieu-cham-soc.js";

import {
  uploadFile,
  getListFile,
  downloadFile,
  deleteFile,
} from "@/api/file-phi-cau-truc.js";
import { saveAs } from "file-saver";
import { getDichVu } from "@/api/danh-muc";

export default {
  props: {
    id: {
      type: Number,
    },
    stt: {
      type: Number,
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  data(vm) {
    return {
      disableActions: {
        modify: !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TheoDoiVaChamSoc/modify"
        ),
        create: !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TheoDoiVaChamSoc/create"
        ),
        export: !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TheoDoiVaChamSoc/export"
        ),
      },
      visible: false,
      tienTrinhUpload: 0,
      loading: false,
      files: null,
      ngayVaoKhoa: null,
      edit: false,
      form,
      dialogVisible: false,
      formDataBa: null,
      capChamSoc: MA_CAP_I,
      rules: {
        sttkhoa: [
          { required: true, message: "Phải chọn khoa", trigger: "change" },
        ],
        maKhoaThucHien: [
          { required: true, message: "Phải chọn khoa", trigger: "change" },
        ],
        ketLuan: [
          { required: true, message: "Mục phải điền", trigger: "change" },
        ],
      },
      checkBoxData: {
        ...dataCheckBoxAsyn,
        ...dataChecBox,
      },
      rules: {
        thayBangViTriThay: [
          { required: true, message: "Mục bắt buộc", trigger: "change" },
        ],
        dieuDuong: [
          { required: true, message: "Mục bắt buộc", trigger: "change" },
        ],
        maBenh: [
          { required: true, message: "Mục bắt buộc", trigger: "change" },
        ],
        ngayChamSoc: [
          { required: true, message: "Mục bắt buộc", trigger: "change" },
        ],
        // mach: [
        //   { required: true, message: 'Mục bắt buộc', trigger: 'change' },
        // ],
        nhietDo: [
          { required: true, message: "Mục bắt buộc", trigger: "change" },
        ],
        // huyetAp: [
        //   { required: true, message: 'Mục bắt buộc', trigger: 'change' },
        // ],
        // nhipTho: [
        //   { required: true, message: 'Mục bắt buộc', trigger: 'change' },
        // ],
      },
    };
  },
  computed: {
    MA_CAP_I() {
      return MA_CAP_I;
    },
    MA_CAP_II() {
      return MA_CAP_II;
    },
    MA_CAP_III() {
      return MA_CAP_III;
    },
  },
  created() {
    this.edit = this.stt ? true : false;
  },
  watch: {},
  mounted() {
    if (this.edit) {
      this.getDsFile();
      this.getData();
    } else {
      this.getDanhMuc();
    }
    this.getBenhKhoaDieuTri();
  },
  methods: {
    changeCapCs() {
      this.capChamSoc = this.form.capCs;
      const modelChecBoxReset = [
        "ythuc",
        "theTrang",
        "hoHap",
        "tietNieu",
        "tieuTien",
        "thuThuatTayY",
        "thayBang",
      ];
      modelChecBoxReset.forEach((it) => {
        this.form[it] = null;
      });
      let dm = danhMucCheckBox.filter((el) =>
        modelChecBoxReset.includes(el.model)
      );
      dm.forEach((el) => {
        this.checkBoxData[el.tenParent] = this.checkBoxData[el.tenParent].map(
          (it) => {
            it.checkbox = false;
            return it;
          }
        );
      });
    },
    setModelCheckBox() {
      danhMucCheckBox.forEach((el) => {
        this.form[el.model] = "";
        this.checkBoxData[el.tenParent].forEach((it) => {
          if (it.checkbox) {
            this.form[el.model] = this.form[el.model] + "," + it.ma;

            // this.form[el.model] = this.form[el.model] ? this.form[el.model].trim() : null;
            // let arrModelCB = this.form[el.model] ? this.form[el.model].split(",") : [];
            // if (!arrModelCB.includes(it.ma)) {
            //   this.form[el.model] = this.form[el.model] ? this.form[el.model] : ''
            //   this.form[el.model] = this.form[el.model] + ',' + it.ma
            // }
          }
        });
        this.form.phu = "";
        this.checkBoxData.phu.forEach((it) => {
          if (it.checkbox) {
            this.form.phu = this.form.phu + "," + it.ma;
          }
        });
        this.form.ythuc = "";
        this.checkBoxData.YThucCSCapI.forEach((it) => {
          if (it.checkbox) {
            this.form.ythuc = this.form.ythuc + "," + it.ma;
          }
        });
        this.checkBoxData.YThucCSCapII.forEach((it) => {
          if (it.checkbox) {
            this.form.ythuc = this.form.ythuc + "," + it.ma;
          }
        });
      });
      console.log(1, this.form);
    },
    async getDanhMuc() {
      let arrPromis = [];
      danhMucCheckBox.forEach((item) => {
        arrPromis.push(getSelectBox({ MaParent: item.maParent }));
      }),
        Promise.all(arrPromis).then((values) => {
          danhMucCheckBox.forEach((item, index) => {
            this.checkBoxData[item.tenParent] = this.setCheckbox(
              this.form[item.model],
              values[index].data
            );
          });
        });
    },
    setCheckbox(model, checkBoxArray) {
      if (model) {
        model = model.trim();
        let arrModel = model.split(",");
        arrModel = arrModel.map((item) => (item = item.trim()));
        return checkBoxArray.map((item) => {
          item.checkbox = false;
          if (arrModel.includes(item.ma)) {
            item.checkbox = true;
          }
          return item;
        });
      }
      return checkBoxArray.map((el) => {
        el.checkbox = false;
        return el;
      });
    },

    goBack() {
      window.location = "/HSBADS/ThongTinTheoDoiVaChamSocNguoiBenh/" + this.id;
    },
    clickUpload() {
      this.$refs["upload-image"].click();
    },
    clickUploadImage(item) {
      this.$refs[`upload-image-${item}`][0].click();
    },
    resetForm() {
      const id = window.location.href.split("/").at(-1);
    },
    async getBenhKhoaDieuTri(params) {
      let data = await apiKhoaDT.index(this.id, params);
      let khoaDt = data.data.find((el) => el.stt == 1);
      this.form.maBenh =
        khoaDt && khoaDt.benhChinh
          ? `${khoaDt.benhChinh.maBenh} - ${khoaDt.benhChinh.tenBenh}`
          : null;
    },
    async getBenhTat(params) {
      return await apiBenhTat.index(params);
    },
    getItemKhoaChamSoc(item) {
      this.ngayVaoKhoa = item.ngayVaoKhoa;
    },
    async getNhanVien(params) {
      return await apiNhanVien.index(params);
    },
    async getKhoa(params) {
      return await apiKhoa.index(params);
    },
    async getKhoaDieuTri(params) {
      return await apiKhoaDT.index(this.id, params);
    },
    async getDSDichVu(params) {
      return await getDichVu({ ...params, MaChungLoai: 4 });
    },
    submit(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          if (this.edit) {
            this.updateData();
          } else this.addData();
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    async updateData() {
      try {
        await apiChamSoc.updatePhieuChamSoc(this.id, this.stt, this.form);
        this.$message({
          message: "Cập nhật thành công.",
          type: "success",
        });
        this.getData();
      } catch {
        console.log(error);
        this.$message({
          message: "Cập nhật không thành công",
          type: "error",
        });
      }
    },
    async addData() {
      console.log(this.form);
      this.form.idba = this.id;
      try {
        await apiChamSoc.addPhieuChamSoc(this.form);
        this.$message({
          message: "Thêm mới thành công.",
          type: "success",
        });
        this.goBack();
      } catch (error) {}
    },
    async getDsFile() {
      let data = await getListFile({
        idba: this.id,
        loaiTaiLieu: 11,
        sttDv: this.stt,
      });
      this.files = data.data;
      this.files.forEach((item) => {
        item.name = item.link.split("\\").at(-1);
      });
    },
    async handleUpload(e) {
      this.tienTrinhUpload = 0;
      var isValidate = true;
      let files = e.target.files;
      if (this.edit) {
        this.loading = true;
        var isValidate = true;
        let data = new FormData();
        if (this.file) {
          return;
        }
        data.append("file", files[0]);
        data.append("idba", this.id);
        data.append("loaiTaiLieu", 11);
        data.append("sttDv", this.stt);
        if (!isValidate) return;
        try {
          await uploadFile(data, (e) => {
            this.tienTrinhUpload = e;
            this.loading = false;
          });
          this.$message({
            message: "Tải lên thành công",
            type: "success",
          });
          this.getDsFile();
        } catch (error) {
          console.log(error);
          this.$message({
            message: "Tải lên không thành công",
            type: "error",
          });
        }
      } else {
        this.files = this.files ? this.files : [];
        for (let el of files) {
          this.files.push(el);
        }
      }
      this.$refs["upload-image"].value = null;
    },
    async removeFile(index, item) {
      if (!this.edit) {
        this.files.splice(index, 1);
      } else {
        await deleteFile(item.idba, item.stt);
        this.getDsFile();
      }
    },
    async getDownloadFile(idba, stt, name) {
      try {
        let data = await downloadFile(idba, stt);
        var blob = new Blob([data]);
        saveAs.saveAs(blob, `${name}`);
      } catch (error) {
        console.log(error);
      }
    },
    async getData() {
      let data = await apiChamSoc.chiTietPhieuChamSoc(this.id, this.stt);
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key];
        }
      }
      console.log(data.data);
      this.form.dieuDuong = data.data.dieuDuong.maNv;
      this.getDanhMuc();
      data = await apiKhoaDT.index(this.id);
      data.data.forEach((item) => {
        if (this.form.sttkhoa == item.stt) {
          this.ngayVaoKhoa = item.ngayVaoKhoa;
        }
      });
    },
  },
};
</script>
<style>
.files {
  padding: 10px;
  width: 100%;
  color: rgb(88, 88, 88);
  display: flex;
  align-items: center;
  justify-content: space-between;
  cursor: pointer;
}

.files:hover {
  background: rgba(231, 231, 231, 0.616);
  font-weight: 500;
}

.box-file {
  cursor: pointer;
  border: 2px dashed #d9d9d9;
  width: 100%;
  height: 90px;
}

.box-file:hover {
  border: 2px dashed #2874a6;
}

.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}

label {
  margin-bottom: -8px !important;
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

.el-dialog__body {
  padding-top: 0px;
}

.avatar-uploader .el-upload {
  border: 1px dashed #d9d9d9;
  border-radius: 6px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
}

.avatar-uploader .el-upload:hover {
  border-color: #409eff;
}

.avatar-uploader-icon {
  font-size: 28px;
  color: #8c939d;
  width: 178px;
  height: 178px;
  line-height: 178px;
  text-align: center;
}

.image-ba {
  width: 178px;
  height: 178px;
  display: block;
}

.el-upload__input {
  display: none !important;
}

.el-checkbox__label {
  font-weight: 400;
}

.el-radio__label {
  font-weight: 400;
}

.width-checkbox {
  width: 100px;
}

.width-checkbox-long {
  width: 170px;
}
</style>
