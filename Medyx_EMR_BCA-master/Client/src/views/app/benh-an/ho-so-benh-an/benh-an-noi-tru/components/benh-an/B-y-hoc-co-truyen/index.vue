<template>
  <div class="pt-2">
    <div style="font-size: 16px; font-weight: bold" class="mb-3 mt-4">
      B. Y HỌC CỔ TRUYỀN
    </div>
    <el-form>
      <v-row>
        <v-col cols="12" class="padding-cols mt-2 mb-1">
          <label>I. VỌNG CHẨN</label>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox">1. Hình thái</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.hinhThaiVongChans" :key="index"
              v-model="item.checkbox">
              {{ item.ten }}
            </el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox">2. Thần</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.ThanVongChans" :key="index"
              v-model="item.checkbox">{{ item.ten }}</el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox">3. Sắc</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.SacVongChan" :key="index"
              v-model="item.checkbox">{{ item.ten }}</el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox">4. Trạch</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.TrachVongChan" :key="index"
              v-model="item.checkbox">{{ item.ten }}
            </el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="5. Lưỡi"></el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3" style="font-style: italic">
              Hình thái
            </div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.HinhThaiLuoi" :key="index"
              v-model="item.checkbox">{{ item.ten }}
            </el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3" style="font-style: italic">
              Chất lưỡi
            </div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.chatLuoi" :key="index"
              v-model="item.checkbox">
              {{ item.ten }}
            </el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3" style="font-style: italic">
              Rêu lưỡi
            </div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.reuLuoi" :key="index"
              v-model="item.checkbox">{{
                  item.ten
              }}
            </el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="6. Mô tả khác (nếu có)">
            <el-input v-model="form.moTaVongChan" type="textarea" rows="3"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-2">
          <label class="mt-2 mb-1">II. VĂN CHẨN</label>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <label>1. Âm thanh</label>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">1.1 Tiếng nói</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.tiengNoi" :key="index"
              v-model="item.checkbox">
              {{ item.ten }}
            </el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">1.2 Hơi thở</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.hoiTho" :key="index"
              v-model="item.checkbox">{{
                  item.ten
              }}
            </el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mr-4">1.3 Ho</div>
            <el-radio-group v-model="form.coHo">
              <el-radio :label="1">Có</el-radio>
              <el-radio :label="2">Không</el-radio>
            </el-radio-group>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.TinhTrangHo" :key="index"
                v-model="item.checkbox">{{ item.ten }}</el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="d-flex mt-3">
              <div class="title-group-checkbox">1.4 Ợ</div>
            </div>
            <el-radio-group v-model="form.oamThanh">
              <el-radio :label="1">Có</el-radio>
              <el-radio :label="2">Không</el-radio>
            </el-radio-group>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="d-flex mt-3">
              <div class="title-group-checkbox">1.5 Nấc</div>
            </div>
            <el-radio-group v-model="form.nacAmThanh">
              <el-radio :label="1">Có</el-radio>
              <el-radio :label="2">Không</el-radio>
            </el-radio-group>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-4">
          <label>2. Mùi</label>
        </v-col>
        <v-col cols="12">
          <el-form-item>
            <div class="title-group-checkbox">2.1. Mùi cơ thể, mùi hơi thở</div>
            <el-radio-group v-model="form.coMui">
              <el-radio :label="1">Có</el-radio>
              <el-radio :label="2">Không</el-radio>
            </el-radio-group>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.muiCoThe" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox">
              2.2. Chất thải biểu hiện bệnh lý
            </div>
            <div>
              <el-radio-group v-model="form.coChatThaiBenhLy">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.chatThai" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="3. Mô tả khác (nếu có)">
            <el-input v-model="form.mtvaanChan" type="textarea" rows="3"></el-input>
          </el-form-item>
        </v-col>

        <v-col cols="12" class="padding-cols mt-2">
          <label class="mt-2 mb-1">III. VẤN CHẨN</label>
        </v-col>

        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">1. Hàn nhiệt</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.bhhanNhiet">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.hanNhiet" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-2">2. Mồ hôi</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.moHoi" :key="index"
              v-model="item.checkbox">{{
                  item.ten
              }}
            </el-checkbox>
          </el-form-item>
        </v-col>

        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">3. Đầu, mặt, cổ</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>

        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.bhdauMatCo">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">Đau đầu</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.dauDau" :key="index"
                v-model="item.checkbox">
                {{ item.ten }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">Hoa mắt chóng mặt</div>
            <div>
              <el-radio-group v-model="form.hoaMat">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">Mắt</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.mat" :key="index"
              v-model="item.checkbox">{{
                  item.ten
              }}
            </el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">Tai</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.tai" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">Mũi</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.mui" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">Họng</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.hong" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">Cổ vai</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.coVai" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">4. Lưng</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.bhlung" class="width-checkbox">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.Lung" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">5. Ngực</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>

        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.bhnguc">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.Nguc" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">6. Bụng</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>

        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.bhbung">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.Bung" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">7. Chân tay</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.bhchanTay" class="width-checkbox">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.chanTay" :key="index"
                v-model="item.checkbox">
                {{ item.ten }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">8. Ăn</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.bhan">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.An" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}</el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">9. Uống</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.bhuong">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.Uong" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">10. Đại tiện, tiểu tiện</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <el-radio-group v-model="form.bhdaiTieuTien">
              <el-radio :label="1">Có</el-radio>
              <el-radio :label="2">Không</el-radio>
            </el-radio-group>
            <div class="title-group-checkbox mt-2">Đại tiện</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.daiTien" :key="index"
                v-model="item.checkbox">
                {{ item.ten }}
              </el-checkbox>
            </div>
            <div class="title-group-checkbox mt-2">Tiểu tiện</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.tieuTien" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">11. Ngủ</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>

        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.bhngu">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.Ngu" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">12. Khả năng sinh dục - sinh sản</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.rlknsinhDuc">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
                <el-radio :label="3">Mãn dục</el-radio>
              </el-radio-group>
            </div>
            <div class="title-group-checkbox mt-2">12.1. Nam giới</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.namGioi" :key="index"
                v-model="item.checkbox">
                {{ item.ten }}
              </el-checkbox>
            </div>
            <div class="title-group-checkbox mt-2">12.2. Nữ giới</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.nuGioi" :key="index"
                v-model="item.checkbox">
                {{ item.ten }}
              </el-checkbox>
            </div>
            <div style="font-weight: 500">
              Kinh nguyệt
              <i style="font-size: 13px" class="ml-1">(Biểu hiện bênh lý)</i>
            </div>
            <div>
              <el-radio-group v-model="form.bhkn">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>+ Rối loạn kinh nguyệt</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.roiLoanKinhNguyet" :key="index"
                v-model="item.checkbox">{{ item.ten }}</el-checkbox>
            </div>
            <div>+ Thống kinh</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.thongKinh" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
            <div style="font-weight: 500">
              Đới hạ
              <i style="font-size: 13px" class="ml-1">(Biểu hiện bênh lý)</i>
            </div>
            <div>
              <el-radio-group v-model="form.bhdoiHa">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.doiHa" :key="index"
                v-model="item.checkbox">{{
                    item.ten
                }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">13. Các yếu tố liên quan đến xuất hiện bệnh</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>

        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.dkxhbenh">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">14. Mô tả khác nếu có</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>

        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <el-input v-model="form.moTaVanChan" type="textarea" rows="3"></el-input>
          </el-form-item>
        </v-col>

        <v-col cols="12" class="padding-cols mt-2">
          <label class="mt-2 mb-1">IV. THIẾT CHẨN</label>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">1. Xúc chấn</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
        </v-col>

        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <el-radio-group v-model="form.bhxucChan">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div class="title-group-checkbox mt-2">Da</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.daXucChan" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
            <div>
              <span class="title-group-checkbox">Cơ - xương - khớp</span>
              <i style="font-size: 13px" class="ml-2">(Biểu hiện bệnh lý)</i>
            </div>
            <div>
              <el-radio-group v-model="form.bhcoXuongKhop">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.coXuongKhopXucChan" :key="index"
                v-model="item.checkbox">{{ item.ten }}</el-checkbox>
            </div>
            <div>
              <span class="title-group-checkbox">Bụng</span>
              <i style="font-size: 13px" class="ml-2">(Biểu hiện bệnh lý)</i>
            </div>
            <div>
              <el-radio-group v-model="form.bhbungXucChan">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.bungXucChan" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
            <div>
              <span class="title-group-checkbox">Mồ hôi</span>
              <i style="font-size: 13px" class="ml-2">(Biểu hiện bệnh lý)</i>
            </div>
            <div>
              <el-radio-group v-model="form.bhmoHoi">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.moHoiXucChan" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-3">
          <label class="mr-2">2. Mạch chấn</label>
          <i style="font-size: 13px">(Biểu hiện bênh lý)</i>
          <div class="mt-2">
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.machChan" :key="index"
              v-model="item.checkbox">{{ item.ten }}
            </el-checkbox>
          </div>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">Tổng khán:</div>
            <div>- Bên trái (Khí, dương):</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.machChanTrai" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
            <div>- Bên phải (Huyết, âm):</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.machChanPhai" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">Vị khán</div>
            <div class="pl-2">- Mạch tay trái:</div>
            <div class="sub-label-ba pl-4">+ Thốn:</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.machChanThonTrai" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
            <div class="sub-label-ba pl-4">+ Quan:</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.machChanQuanTrai" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
            <div class="sub-label-ba pl-4">+ Xích:</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.machChanXichTrai" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
            <div class="pl-2">Mạch tay phải:</div>
            <div class="sub-label-ba pl-4">+ Thốn:</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.machChanThonPhai" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
            <div class="sub-label-ba pl-4">+ Quan</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.machChanQuanPhai" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
            <div class="sub-label-ba pl-4">+ Xích:</div>
            <div>
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.machChanXichPhai" :key="index"
                v-model="item.checkbox">{{ item.ten }}
              </el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">3. Mô tả khác (nếu có)</div>
            <el-input v-model="form.mtthietChan" type="textarea" rows="4"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-2">
          <label class="mt-2 mb-1">V. TÓM TẮT TỨ CHẨN</label>
        </v-col>

        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <el-input v-model="form.tomTatTuChan" type="textarea" rows="4"></el-input>
          </el-form-item>
        </v-col>

        <v-col cols="12" class="padding-cols mt-2">
          <label class="mt-2 mb-1">VI. BIỆN CHỨNG LUẬN TRỊ</label>
        </v-col>

        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <el-input v-model="form.bienChungLuanTri" type="textarea" rows="4"></el-input>
          </el-form-item>
        </v-col>

        <v-col cols="12" class="padding-cols mt-2">
          <label class="mt-2 mb-1">VII. CHẨN ĐOÁN</label>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">1. Bệnh danh</div>
            <base-select-async v-model="form.maBenhDanhTheoYhct" :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`" 
              keyValue="maBenh" :apiFunc="getChanDoanBenhCT" placeholder="" style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">2. Bát cương</div>
            <div>
              <el-input v-model="form.batCuong" size="small"></el-input>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">Biểu hiện bát cương</div>
            <div style="width: 100%">
              <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.batCuong" :key="index"
                v-model="item.checkbox">{{ item.ten }}</el-checkbox>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">3. Nguyên nhân</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.nguyenNhan" :key="index"
              v-model="item.checkbox">{{ item.ten }}</el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">4. Tạng phủ</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.tangPhu" :key="index"
              v-model="item.checkbox">{{
                  item.ten
              }}</el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">5. Kinh mạch</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.kinhMach" :key="index"
              v-model="item.checkbox">
              {{ item.ten }}</el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div class="title-group-checkbox mt-3">6. Định vị bệnh</div>
            <el-checkbox class="width-checkbox" @change="getcheckBoxMode(checkBoxData)" v-for="(item, index) in checkBoxData.dinhViBenhTheo" :key="index"
              v-model="item.checkbox">{{ item.ten }}</el-checkbox>
          </el-form-item>
        </v-col>
      </v-row>
    </el-form>
  </div>
</template>

<script>
import * as apiBenhTatCT from "@/api/benh-tat-yhct.js";
import { getSelectBox } from "@/api/danh-muc.js";
import { getKhamYhct } from "@/api/benh-an.js";
import { checkBoxData, form, danhMucData } from "./dataHelper";
export default {
  data: () => ({
    form,
    checkBoxData,
    benhAnYhct:[],
  }),
  mounted() {
    this.getData();
  },
  watch: {
    form: {
      handler(val) {
        this.$emit('get-phanB', val, this.benhAnYhct)
      },
      deep: true
    },
  },
  methods: {
    async getChanDoanBenhCT(params) {
      return await apiBenhTatCT.index(params);
    },
    async getDanhMuc() {
      let arrPromis = [];
      danhMucData.forEach(item => {
        arrPromis.push(getSelectBox({ MaParent: item.MaParent }))
      }),
        Promise.all(arrPromis).then((values) => {
          danhMucData.forEach((item, index) => {
            this.checkBoxData[item.Data] = this.setCheckbox(
              this.form[item.Model],
              values[index].data
            );
          })
        });
    },
    async getData() {
      const id = window.location.href.split("/").at(-1);
      let data = await getKhamYhct(id);
      this.benhAnYhct=data.data
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key];
        }
      }
      await this.getDanhMuc();
    },
    
    setCheckbox(model, checkBoxArray) {
      if (model) {
        let arrModel = model.split(",")
        arrModel = arrModel.map((item) => (item = item.trim()));
        return checkBoxArray.map((item) => {
          item.checkbox = false;
          if (arrModel.includes(item.ma)) {
            item.checkbox = true;
          }
          return item;
        });
      }
      return checkBoxArray
    },

    getcheckBoxMode(checkBoxList){
        for(var lableKey in checkBoxList){
          let checkBoxItem = danhMucData.find(el => el.Data == lableKey);
          let modelName = checkBoxItem.Model;
          let arrCheckBox = checkBoxList[lableKey]
          this.setModelFormCheckbox(arrCheckBox, modelName)
        }
    },
    setModelFormCheckbox(arrCheckbox, modelName){
      let ma="";
      arrCheckbox.forEach(item=>{
        if(item.checkbox){
          ma=ma+item.ma+","
        }
      }) 
      this.form[modelName]=ma;
    }
  },
};
</script>

<style>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}

.title-group-checkbox {
  font-weight: 500;
  line-height: 20px;
}

.width-checkbox {
  width: 200px;
}

.sub-label-ba {
  font-weight: 500;
  font-style: italic;
  border-bottom: 1px solid #bdc3c7;
  width: 80px;
  line-height: auto;
}
</style>
