import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import ElementUI from 'element-ui';
import axios from 'axios';
import 'element-ui/lib/theme-chalk/index.css';
import VueCookies from 'vue-cookies'
Vue.use(VueCookies);
Vue.use(ElementUI);
Vue.prototype.$axios=axios;
Vue.config.productionTip = false
axios.defaults.headers.common['Authorization'] = `bearer ${VueCookies.get('Taken')}` ;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
