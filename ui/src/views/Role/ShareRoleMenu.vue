<template>
    <div>
<el-tree
v-model="id"
  :data="data"
  show-checkbox
  node-key="menuId"
  :default-expanded-keys="[2, 3]"
  :default-checked-keys="ids"
  ref="menuTree"
  :props="defaultProps">
</el-tree>
    </div>
</template>

<script>
  export default {
    props:['menuid'],
    data() {
      return {
        data:[],
        id:this.menuid,
        ids:[],
        defaultProps: {
          children: 'children',
          label: 'menuName'
        }
      };
    },
    methods:{
        showRoleInfor()
        {
             this.$axios.get("https://localhost:44349/api/MenuManger/getAll").then
            (
                res=>{
                    this.data=res.data;
                    this.id=this.menuId;
                }
                
            )
        },
        bindid()
        {
          this.$axios.get("/api/Role/GetMenuRoles?roleid="+this.id).then(

            res=>{
              debugger
              this.ids=res.data;
              console.log(this.ids);
            }
          )
        }
    },
    created()
    {
      console.log(this.id);
        this.showRoleInfor();
        this.bindid();
    }
  };
</script>