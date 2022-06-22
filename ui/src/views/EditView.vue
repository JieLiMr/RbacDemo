<template>
    <div>
     <el-form ref="form" :model="form" label-width="80px">
    <el-form-item label="父级菜单">
      <el-cascader
      v-model="form.ParentId"
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
    props:["EditData"],
    data() {
      return {
        options: [],
        form:{
            MenuName:'',
            LinkUrl:'',
            MenuId:'',
            ParentId:''
        }
      };
    },
    mounted()
    {   
       this.showDate();
      this.getMenu(this.EditData);

       
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
          debugger
            this.form.ParentId=value[value.length-1]
       
        console.log(this.form.menuId)
      },
      onSubmit()
      {
        debugger 
        this.$axios.post("https://localhost:44349/api/MenuManger/Edit",this.form).then
                    (
                        res=>{
                            if(res.data)
                            {
                                this.$message.success('修改成功');      
                                this.$emit("edit",true)                        
                            }
                            else
                            {
                              this.$message.warning('修改失败');
                            }
                            
                        }
                    )
      },
      getMenu(val)
      {

            this.form.ParentId=val.menuId;
            this.form.MenuId=val.menuId;
            this.form.MenuName=val.menuName;
            this.form.LinkUrl=val.linkUrl;      
       
      }
    },
    created()
    {

    },
       watch:{
        EditData:function (newval,oldval)
        {
          debugger

          this.getMenu(newval);
         console.log(newval,oldval);
        }
    },
  };
</script>