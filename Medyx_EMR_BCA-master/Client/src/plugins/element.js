import Vue from "vue";
import {
  Tooltip,
  Popconfirm,
  Button,
  Notification,
  MessageBox,
  Message,
  Dialog,
  Option,
  Upload,
  Select,
  Input,
  Form,
  FormItem,
  Table,
  TableColumn,
  Pagination,
  Loading,
  Radio,
  RadioGroup,
  InputNumber,
  Descriptions,
  DescriptionsItem,
  Skeleton,
  SkeletonItem,
  Checkbox,
  CheckboxGroup,
  CheckboxButton,
  Badge,
  Collapse,
  CollapseItem,
  Card
} from "element-ui";
import lang from "element-ui/lib/locale/lang/vi";
import locale from "element-ui/lib/locale";
import "element-ui/lib/theme-chalk/index.css";
locale.use(lang);

Vue.use(Tooltip);
Vue.use(Popconfirm);

Vue.use(Dialog);
Vue.use(Upload);
Vue.use(Option);
Vue.use(Button);
Vue.use(Checkbox);
Vue.use(CheckboxGroup);
Vue.use(CheckboxButton);
Vue.use(Select);
Vue.use(Input);
Vue.use(Form);
Vue.use(FormItem);
Vue.use(Table);
Vue.use(Card);
Vue.use(Radio);
Vue.use(RadioGroup);
Vue.use(InputNumber);
Vue.use(TableColumn);
Vue.use(Pagination);
Vue.use(Descriptions);
Vue.use(DescriptionsItem);
Vue.use(Skeleton);
Vue.use(SkeletonItem);
Vue.use(Badge);
Vue.use(Collapse);
Vue.use(CollapseItem);
Vue.use(Loading.directive);
Vue.prototype.$msgbox = MessageBox;
Vue.prototype.$alert = MessageBox.alert;
Vue.prototype.$confirm = MessageBox.confirm;
Vue.prototype.$prompt = MessageBox.prompt;
Vue.prototype.$notify = Notification;
Vue.prototype.$message = Message;
Vue.prototype.$loading = Loading.service;
