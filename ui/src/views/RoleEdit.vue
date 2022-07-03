<template>
    <div>
<el-tree
v-model="id"
  :data="data"
  show-checkbox
  node-key="menuId"
  :default-expanded-keys="[2, 3]"
  :default-checked-keys="[5]"
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
                    console.log(this.menuArr)
                }
                
            )
        }
    },
    created()
    {
        this.showRoleInfor();
    }
  };
</script>