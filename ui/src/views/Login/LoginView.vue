<template>
  <div class="login" clearfix>
    <div class="login-wrap">
      <el-row type="flex" justify="center">
        <el-form ref="user" :model="user" :rules="rules" status-icon label-width="80px" >
          <h3>登录</h3>
          <hr>
          <el-form-item prop="username" label="用户名">
            <el-input v-model="user.username" placeholder="请输入用户名" prefix-icon></el-input>
          </el-form-item>
          <el-form-item id="password" prop="password" label="密码">
            <el-input v-model="user.password" show-password placeholder="请输入密码"></el-input>
          </el-form-item>
           <el-form-item id="password" prop="email" label="验证码" >
            <el-input v-model="user.email"  placeholder="请输入验证码" :inline="true" ></el-input>
            <img :src="imgpath" width="100px" :inline="true">
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
        password: "",
        email:""
      },
      imgpath:`${this.$axios.defaults.baseURL}/api/Admin/Captcha`,
       rules:{
         username: [
            { required: true, message: '请输入用户名', trigger: 'blur' },
            
          ],
          password: [
            { required: true, message: '请输入密码', trigger: 'change' }
          ],
            email: [
            { required: true, message: '请输入密码', trigger: 'change' }
          ],
       }

    };
  },
  created() {},
  mounted()
  {
    //this.Captcha();
  },
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
        this.$axios
          .post("/api/Admin/Loign", {
            userName: this.user.username,
            password: this.user.password,
            email:this.user.email
          })
          .then(res => {
            if (res.data.code==1) {
              debugger
             Cookies.set('Taken',res.data.jwtCode) 
             this.$axios.defaults.headers.common['Authorization'] = `bearer ${Cookies.get('Taken')}` ;
              this.$router.push({ path: "/home" });
            }
             else {
              alert("您输入的用户名或密码错误！");
            }
          });
      }
    },
    Captcha()
    {
       this.$axios.get("/api/Admin/Captcha",{responseType:'blob'}).then
            (
                res=>{
                    this.imgpath=window.URL.createObjectURL(res.data);
                }
                
            )
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
  width: 450px;
  height: 450px;
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