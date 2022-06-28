<template>
  <div class="login" clearfix>
    <div class="login-wrap">
      <el-row type="flex" justify="center">
        <el-form ref="user" :model="user" :rules="rules" status-icon label-width="80px">
          <h3>登录</h3>
          <hr>
          <el-form-item prop="username" label="用户名">
            <el-input v-model="user.username" placeholder="请输入用户名" prefix-icon></el-input>
          </el-form-item>
          <el-form-item id="password" prop="password" label="密码">
            <el-input v-model="user.password" show-password placeholder="请输入密码"></el-input>
          </el-form-item>
           <el-form-item id="password" prop="password" label="验证码">
            <el-input v-model="user.password" show-password placeholder="请输入验证码"></el-input>
            <img src="" alt="">
          </el-form-item>
          <router-link to="/">找回密码</router-link>
          <router-link to="/register">注册账号</router-link>
          <el-form-item>
            <el-button type="primary" icon="el-icon-upload" @click="doLogin()">登 录</el-button>
          </el-form-item>
        </el-form>
      </el-row>
    </div>
  </div>
</template>
 
<script>
import Cookies from 'js-cookie'
export default {
  name: "login",
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
       rules:{
         username: [
            { required: true, message: '请输入用户名', trigger: 'blur' },
            
          ],
          password: [
            { required: true, message: '请输入密码', trigger: 'change' }
          ],
       }

    };
  },
  created() {},
  methods: {
    doLogin() {
      if (!this.user.username) {
        this.$message.error("请输入用户名！");
        return;
      }
       else if (!this.user.password) {
        this.$message.error("请输入密码！");
        return;
      } else {
        //校验用户名和密码是否正确;
        // this.$router.push({ path: "/personal" });
        this.$axios
          .post("https://localhost:44349/api/Admin/Loign", {
            userName: this.user.username,
            password: this.user.password
          })
          .then(res => {
            if (res.data.code==1) {
             console.log(Cookies.set('Taken',res.data.jwtCode)) 
              this.$router.push({ path: "/home" });
            }
             else {
              alert("您输入的用户名或密码错误！");
            }
          });
      }
    }
  }
};
</script>
 

<style scoped>
.login {
  width: 100%;
  height: 800px;
  /* background: url("../assets/images/bg1.png") no-repeat; */
  background-size: cover;
  overflow: hidden;
}
.login-wrap {
  /* background: url("../assets/images/login_bg.png") no-repeat; */
  background-size: cover;
  width: 400px;
  height: 350px;
  margin: 215px auto;
  overflow: hidden;
  padding-top: 10px;
  line-height: 40px;
}
#password {
  margin-bottom: 5px;
}
h3 {
  color: #0babeab8;
  font-size: 24px;
}
hr {
  background-color: #444;
  margin: 20px auto;
}
a {
  text-decoration: none;
  color: #aaa;
  font-size: 15px;
}
a:hover {
  color: coral;
}
.el-button {
  width: 80%;
  margin-left: -50px;
}
</style>