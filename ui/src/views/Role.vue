<template>
    <div>
    <el-table
    :data="tableData"
    style="width: 100%">
    <el-table-column
      label="编号"
      width="180">
      <template slot-scope="scope">
        <span style="margin-left: 10px">{{ scope.row.roleId }}</span>
      </template>
    </el-table-column>
    <el-table-column
      label="角色名称"
      width="180">
      <template slot-scope="scope">
          <p>{{ scope.row.roleName }}</p>
      </template>
    </el-table-column>
    <el-table-column label="操作">
      <template slot-scope="scope">
        <el-button
          size="mini"
          @click="handleEdit(scope.row.roleId)">授权</el-button>
        <el-button
          size="mini"
          type="danger"
          @click="handleDelete(scope.$index, scope.row)">删除</el-button>
      </template>
    </el-table-column>
  </el-table>
      <el-dialog
  title="修改"
  :visible.sync="dialogVisible"
  width="30%"
  :before-close="handleClose">
    <role-edit ref="dialogTree" :menuid="menuId"></role-edit>
  <span slot="footer" class="dialog-footer">
    <el-button @click="dialogVisible = false">取 消</el-button>
    <el-button type="primary" @click="saveInfor">确 定</el-button>
  </span>
</el-dialog>
    </div>
</template>
<script>
import roleEdit from '../views/RoleEdit.vue';
export default {
name: "Role",
components: {
    roleEdit,
  },
    data()
    {
        return{
            tableData:[],
            menuId:'',
            dialogVisible:false
        }
    },
    methods:{
        handleClose()
        {
            this.dialogVisible=false;
        },
        showRoleInfor()
        {
            this.$axios.get("/api/Role/getAll").then
            (
                res=>{
                    this.tableData=res.data;
                }
            )
        },
        handleEdit(val)
        {
            this.menuId=val;
            console.log(this.menuId);
            this.dialogVisible=true;

        },
        saveInfor()
        {
            var checkedId = this.$refs.dialogTree.$refs.menuTree.getCheckedNodes(true, true).map(m => m.menuId);
            debugger
                var roleId = this.menuId;
                this.$axios.post('/api/Role/MenuRoleAdd', { id: roleId, roleId:checkedId}).then(m => {
                    if(m.data)
                    {
                        this.$message.success("授权成功");
                    }
                });
                /**
                 * 1、父组件获取
                 * 2、子组件获取
                */
                //console.log(this.$refs.dialogTree.getdata());
                this.dialogVisible = false;
        }
    },
    created()
    {
        this.showRoleInfor();
    }
}
</script>