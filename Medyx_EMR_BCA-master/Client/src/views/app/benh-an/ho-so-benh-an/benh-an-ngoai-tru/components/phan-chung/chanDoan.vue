<template>
  <div>
    <div style="font-size: 16px; font-weight: bold" class="mb-4">
      III. CHẨN ĐOÁN
    </div>
    <el-form>
      <v-row>
        <v-col cols="12">
          <div style="border: 1px solid #d6dbdf" class="pa-4 pb-8">
            <v-row class="mt-0">
              <v-col cols="12" class="padding-cols mb-2">
                <div style="font-weight: 600" class="pb-1">
                  CHẨN ĐOÁN THEO YHHĐ
                </div>
                <hr />
              </v-col>
              <v-col cols="12" class="padding-cols">
                <b>Chẩn đoán của nơi chuyển đến</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhNoiChuyenDenYhhd"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    size="small"
                    @get-item="getTenBenhNoiChuyenDenYhhd"
                    clearable
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhNoiChuyenDenYhhd"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="mt-3">
                <b>Chẩn đoán KKB/cấp cứu</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKkbyhhd"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKkbyhhd"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKkbyhhd"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="6">
                <el-form-item label="Thủ thuật">
                  <el-radio-group
                    v-model="form.thuThuatYhhd"
                    style="width: 100%"
                  >
                    <el-radio :label="1">Có</el-radio>
                    <el-radio :label="2">Không</el-radio>
                  </el-radio-group>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Ra viện - Bệnh chính</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhChinhRv"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhChinhRv"
                    :firstEmitGetItem="false"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhChinhRv"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Ra viện - Bệnh kèm theo 1</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKemRv1"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKemRv1"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKemRv1"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Ra viện - Bệnh kèm theo 2</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKemRv2"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKemRv2"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKemRv2"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Ra viện - Bệnh kèm theo 3</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKemRv3"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKemRv3"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKemRv3"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="6" class="padding-cols">
                <el-form-item label="Tai biến">
                  <el-radio-group
                    v-model="form.taiBienYhhd"
                    style="width: 100%"
                  >
                    <el-radio :label="1">Có</el-radio>
                    <el-radio :label="2">Không</el-radio>
                  </el-radio-group>
                </el-form-item>
              </v-col>
              <v-col cols="6" class="padding-cols">
                <el-form-item label="Biến chứng">
                  <el-radio-group
                    v-model="form.bienChungYhhd"
                    style="width: 100%"
                  >
                    <el-radio :label="1">Có</el-radio>
                    <el-radio :label="2">Không</el-radio>
                  </el-radio-group>
                </el-form-item>
              </v-col>
            </v-row>
          </div>
        </v-col>
        <v-col cols="12">
          <div style="border: 1px solid #d6dbdf" class="pa-4 pb-8">
            <v-row class="mt-0">
              <v-col cols="12" class="padding-cols mb-2">
                <div style="font-weight: 600" class="pb-1">
                  CHẨN ĐOÁN THEO YHCT
                </div>
                <hr />
              </v-col>
              <v-col cols="12" class="padding-cols">
                <b>Chẩn đoán của nơi chuyển đến</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhNoiChuyenDenYhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenhCT"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhNoiChuyenDenYhct"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhNoiChuyenDenYhct"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="mt-3">
                <b>Chẩn đoán KKB/cấp cứu</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKkbyhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenhCT"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKkbyhct"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKkbyhct"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Vào khoa điều trị - bệnh chính</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhChinhVvyhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenhCT"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhChinhVvyhct"
                    :firstEmitGetItem="false"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhChinhVvyhct"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Vào khoa điều trị - bệnh kèm 1</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKemVv1yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenhCT"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKemVv1yhct"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKemVv1yhct"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Vào khoa điều trị - bệnh kèm 2</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKemVv2yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenhCT"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKemVv2yhct"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKemVv2yhct"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Vào khoa điều trị - bệnh kèm 3</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKemVv3yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenhCT"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKemVv3yhct"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKemVv3yhct"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="6">
                <el-form-item label="Thủ thuật">
                  <el-radio-group
                    v-model="form.thuThuatYhct"
                    style="width: 100%"
                  >
                    <el-radio :label="1">Có</el-radio>
                    <el-radio :label="2">Không</el-radio>
                  </el-radio-group>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Ra viện - Bệnh chính</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhChinhRvyhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenhCT"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhChinhRvyhct"
                    :firstEmitGetItem="false"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhChinhRvyhct"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Ra viện - Bệnh kèm theo 1</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKemRv1yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenhCT"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKemRv1yhct"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKemRv1yhct"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Ra viện - Bệnh kèm theo 2</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKemRv2yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenhCT"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKemRv2yhct"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKemRv2yhct"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="12">
                <b>Ra viện - Bệnh kèm theo 3</b>
              </v-col>
              <v-col
                class="padding-cols"
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="4"
                xl="4"
              >
                <el-form-item label="Mã bệnh">
                  <base-select-async
                    v-model="form.maBenhKemRv3yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.tenBenhBhyt}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenhCT"
                    placeholder=""
                    style="width: 100%"
                    clearable
                    size="small"
                    @get-item="getTenBenhKemRv3yhct"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col
                cols="12"
                xs="12"
                sm="12"
                md="12"
                lg="8"
                xl="8"
                class="padding-cols"
              >
                <el-form-item label="Tên bệnh">
                  <el-input
                    v-model="form.tenBenhKemRv3yhct"
                    size="small"
                    placeholder="Tên bệnh"
                  ></el-input>
                </el-form-item>
              </v-col>
              <v-col cols="6" class="padding-cols">
                <el-form-item label="Tai biến">
                  <el-radio-group
                    v-model="form.taiBienYhct"
                    style="width: 100%"
                  >
                    <el-radio :label="1">Có</el-radio>
                    <el-radio :label="2">Không</el-radio>
                  </el-radio-group>
                </el-form-item>
              </v-col>
              <v-col cols="6" class="padding-cols">
                <el-form-item label="Biến chứng">
                  <el-radio-group
                    v-model="form.bienChungYhct"
                    style="width: 100%"
                  >
                    <el-radio :label="1">Có</el-radio>
                    <el-radio :label="2">Không</el-radio>
                  </el-radio-group>
                </el-form-item>
              </v-col>
            </v-row>
          </div>
        </v-col>
      </v-row>
    </el-form>
  </div>
</template>

<script>
import * as apiBenhTat from "@/api/benh-tat.js";
import * as apiBenhTatCT from "@/api/benh-tat-yhct.js";
import { getBenhTat } from "@/api/phieu-kham-benh-vao-vien";
import store from '@/store'

export default {
  props: ["benhAn", "benhAnKhoaDieuTri"],
  data: () => ({
    form: {
      maBenhNoiChuyenDenYhct: null,
      maBenhNoiChuyenDenYhhd: null,
      maBenhKkbyhct: null,
      maBenhKkbyhhd: null,
      maBenhChinhRv: null,
      maBenhChinhRvyhct: null,
      maBenhKemRv1: null,
      maBenhKemRv1yhct: null,
      maBenhKemRv2: null,
      maBenhKemRv2yhct: null,
      maBenhKemRv3: null,
      maBenhKemRv3yhct: null,
      tenBenhNoiChuyenDenYhct: null,
      tenBenhNoiChuyenDenYhhd: null,
      tenBenhKkbyhct: null,
      tenBenhKkbyhhd: null,
      tenBenhChinhRv: null,
      tenBenhChinhRvyhct: null,
      tenBenhKemRv1: null,
      tenBenhKemRv1yhct: null,
      tenBenhKemRv2: null,
      tenBenhKemRv2yhct: null,
      tenBenhKemRv3: null,
      tenBenhKemRv3yhct: null,
      phauThuatYhct: null,
      phauThuatYhhd: null,
      taiBienYhct: null,
      taiBienYhhd: null,
      thuThuatYhct: null,
      thuThuatYhhd: null,
      bienChungYhct: null,
      bienChungYhhd: null,
      maBenhChinhVvyhct: null,
      maBenhKemVv1yhct: null,
      maBenhKemVv2yhct: null,
      maBenhKemVv3yhct: null,
      tenBenhChinhVvyhct: null,
      tenBenhKemVv1yhct: null,
      tenBenhKemVv2yhct: null,
      tenBenhKemVv3yhct: null,
      benhChinh: {
        maBenh: null,
        tenBenh: null,
      },
      benhKem1: {
        maBenh: null,
        tenBenh: null,
      },
      benhKem2: {
        maBenh: null,
        tenBenh: null,
      },
      benhKem3: {
        maBenh: null,
        tenBenh: null,
      },
    },
    chanDoan: [
      {
        maChanDoan: null,
        tenChanDoan: null,
      },
    ],
  }),
  watch: {
    benhAn: function (val) {
      for (let key in this.form) {
        if (val && val.hasOwnProperty(key)) {
          this.form[key] = val[key];
        }
      }
    },
    benhAnKhoaDieuTri: function (val) {
      for (let key in this.form) {
        if (val && val.hasOwnProperty(key)) {
          this.form[key] = val[key];
        }
      }
    },
    form: {
      handler(val) {
        this.$emit('get-chanDoan', val)
        store.dispatch("hosobenhan/setChanDoan", val)
      },
      deep: true
    },
    CHANDOAN:{
      handler(val) {
        for (let key in this.form) {
          if (val && val.hasOwnProperty(key)) {
            this.form[key] = val[key]
          }
        }
      },
      deep: true
    },
    TONGKETRAVIEN: {
      handler(val) {
        for (let key in this.form) {
          if (val && val.hasOwnProperty(key)) {
            this.form[key] = val[key]
          }
        }
      },
      deep: true
    }
  },
  computed: {
    TONGKETRAVIEN(){
      return this.$store.state.hosobenhan.tongKetRaVien
    },
    CHANDOAN(){
      return this.$store.state.hosobenhan.chanDoanYHHD
    },

  },
  mounted() {},
  methods: {
    async getChanDoanBenh(params) {
      return await apiBenhTat.index(params);
    },
    async getChanDoanBenhCT(params) {
      return await apiBenhTatCT.index(params);
    },
    getTenBenhNoiChuyenDenYhhd(item) {
      if(item){
        this.form.tenBenhNoiChuyenDenYhhd = item.tenBenh;
      }
      else{
        this.form.tenBenhNoiChuyenDenYhhd = null
      }
    },
    getTenBenhKkbyhhd(item) {
      if(item){
        this.form.tenBenhKkbyhhd = item.tenBenh;
      }
      else{
        this.form.tenBenhKkbyhhd=null
      }
    },
    // getTenBenhChinhVv(item) {
    //   if(item){
    //     this.form.benhChinh.tenBenh = item.tenBenh;
    //   }
    //   else{
    //     this.form.benhChinh.tenBenh=null
    //   }
    // },
    // getTenBenhKem1Vv(item) {
    //   if(item){
    //     this.form.benhKem1.tenBenh = item.tenBenh;
    //   }
    //   else{
    //     this.form.benhKem1.tenBenh=null
    //   }
    // },
    // getTenBenhKem2Vv(item) {
    //   if(item){
    //     this.form.benhKem2.tenBenh = item.tenBenh;
    //   }
    //   else{
    //     this.form.benhKem2.tenBenh=null
    //   }
    // },
    // getTenBenhKem3Vv(item) {
    //   if(item){
    //     this.form.benhKem3.tenBenh = item.tenBenh;
    //   }
    //   else{
    //     this.form.benhKem3.tenBenh=null
    //   }
    // },
    getTenBenhKkbyhct(item) {
      if(item){
        this.form.tenBenhKkbyhct = item.tenBenh;
      }
      else{
        this.form.tenBenhKkbyhct=null
      }
    },
    getTenBenhNoiChuyenDenYhct(item) {
      if(item){
        this.form.tenBenhNoiChuyenDenYhct = item.tenBenh;
      }
      else{
        this.form.tenBenhNoiChuyenDenYhct=null
      }
    },
    getTenBenhChinhRv(item) {
      if(item){
        this.form.tenBenhChinhRv = item.tenBenh;
      }
      else{
        this.form.tenBenhChinhRv=null
      }
    },
    getTenBenhChinhRvyhct(item) {
      if(item){
        this.form.tenBenhChinhRvyhct = item.tenBenh;
      }
      else{
        this.form.tenBenhChinhRvyhct=null
      }
    },
    getTenBenhKemRv1(item) {
      if(item){
        this.form.tenBenhKemRv1 = item.tenBenh;
      }
      else{
        this.form.tenBenhKemRv1=null
      }
    },
    getTenBenhKemRv1yhct(item) {
      if(item){
        this.form.tenBenhKemRv1yhct = item.tenBenh;
      }
      else{
        this.form.tenBenhKemRv1yhct=null
      }
    },
    getTenBenhKemRv2(item) {
      if(item){
        this.form.tenBenhKemRv2 = item.tenBenh;
      }
      else{
        this.form.tenBenhKemRv2=null
      }
    },
    getTenBenhKemRv2yhct(item) {
      if(item){
        this.form.tenBenhKemRv2yhct = item.tenBenh;
      }
      else{
        this.form.tenBenhKemRv2yhct=null
      }
    },
    getTenBenhKemRv3(item) {
      if(item){
        this.form.tenBenhKemRv3 = item.tenBenh;
      }
      else{
        this.form.tenBenhKemRv3=null
      }
    },
    getTenBenhKemRv3yhct(item) {
      if(item){
        this.form.tenBenhKemRv3yhct = item.tenBenh;
      }
      else{
        this.form.tenBenhKemRv3yhct=null
      }
    },
    getTenBenhChinhVvyhct(item) {
      if(item){
        this.form.tenBenhChinhVvyhct = item.tenBenh;
      }
      else{
        this.form.tenBenhChinhVvyhct=null
      }
    },
    getTenBenhKemVv1yhct(item) {
      if(item){
        this.form.tenBenhKemVv1yhct = item.tenBenh;
      }
      else{
        this.form.tenBenhKemVv1yhct=null
      }
    },
    getTenBenhKemVv2yhct(item) {
      if(item){
        this.form.tenBenhKemVv2yhct = item.tenBenh;
      }
      else{
        this.form.tenBenhKemVv2yhct=null
      }
    },
    getTenBenhKemVv3yhct(item) {
      if(item){
        this.form.tenBenhKemVv3yhct = item.tenBenh;
      }
      else{
        this.form.tenBenhKemVv3yhct=null
      }
    },
  },
};
</script>

<style scoped>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}
</style>
