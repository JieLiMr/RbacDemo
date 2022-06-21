<template>
    <div>
     <el-form ref="form" :model="form" label-width="80px">
    <el-form-item label="父级菜单">
      <el-cascader
      ref="ddp"
    :options="options"
    @change="handleChange"
    :props="{ checkStrictly: true }"
    clearable>
    </el-cascader>
  </el-form-item>
  <el-form-item label="路由">
   <el-input v-model="form.LinkUrl"></el-input>
  </el-form-item>
  <el-form-item label="菜单名字">
    <el-input v-model="form.MenuName"></el-input>
  </el-form-item>
  <el-form-item>
    <el-button type="primary" @click="onSubmit">添加</el-button>
    <el-button>取消</el-button>
  </el-form-item>
</el-form>

    </div>
</template>
<script>
  export default {
    data() {
      return {
        options: [],
        form:{
            MenuName:'',
            LinkUrl:'',
            ParentId:''
        }
      };
    },
    mounted()
    {
       
        console.log( this.$refs.ddp)
        this.showDate();
    },
    methods:{
        showDate()
        {
            this.$axios.get("https://localhost:44349/api/MenuManger/GetAddDtoAll").then
            (
                res=>{
                    var reg = new RegExp('\\,"children":\\[]', 'g')
                    this.options=JSON.parse(JSON.stringify(res.data).replace(reg, ''));
                    
                }
            )
        },
        handleChange(value) {
             console.log( this.$refs.form)
        this.form.ParentId=value[value.length-1]
        console.log(this.form.ParentId)
      },
      onSubmit()
      {
        this.$axios.post("https://localhost:44349/api/MenuManger/AddMenu",this.form).then
                    (
                        res=>{
                            if(res.data)
                            {
                                this.$message.success('添加成功');
                            }
                            
                        }
                    )
      }
    },
    created()
    {

    }
  };
</script>