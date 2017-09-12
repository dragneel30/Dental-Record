using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DentalRecordApplication
{
    class Queries
    {

        public const String insert_patient_info = "insert into patient_info(firstname, middlename, lastname, address, occupation, contactnumber, age, status, gender, complain) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
        public const String select_patient_info = "select * from patient_info";
        public const String select_patient_info_id_latest = "select max(patient_id) as patient_id from patient_info";
        public const String select_patient_info_based_patient_id = "select * from patient_info where patient_id = '{0}'";
        public const String select_patient_info_based_lastname = "select * from patient_info where lastname = '{0}'";
        public const String update_patient_info_single_data = "update patient_info set {0} = '{1}' where patient_id = '{2}'";
        public const String delete_patient_info_based_id = "delete from patient_info where patient_id = '{0}'";
        public const String insert_history_info = "insert into history_info(patient_id, disease) values('{0}', '{1}')";
        public const String select_history_info = "select * from history_info";
        public const String select_history_info_disease_based_id = "select disease from history_info where patient_id = '{0}'";
        public const String delete_history_info_based_patient_id = "delete from history_info where patient_id = '{0}'";
        public const String insert_question_info = "insert into question_info(patient_id, question, answer) values('{0}', '{1}', {2})";
        public const String select_question_info = "select * from question_info";
        public const String select_question_info_answer_based_patient_id = "select answer from question_info where patient_id = '{0}'";
        public const String delete_question_info_based_patient_id = "delete from question_info where patient_id = '{0}'";
        public const String insert_task_info = "insert into task_info(code, name, cost, description) values('{0}', '{1}', '{2}', '{3}')";
        public const String select_task_info = "select * from task_info";
        public const String select_task_info_cost_based_code_and_name = "select cost from task_info where code = '{0}' and name = '{1}'";
        public const String select_task_info_code = "select code from task_info";
        public const String delete_teeth_diagram_info_based_teeth_id = "delete from teeth_diagram_info where teeth_id = '{0}'";
        public const String update_task_info_single_data_based_id = "update task_info set {0} = '{1}' where id = '{2}'";
        public const String delete_task_info_based_id = "delete from task_info where id = '{0}'";
        public const String insert_teeth_info = "insert into teeth_info(patient_id, number, part, is_permanent, area) values('{0}', '{1}', '{2}', {3}, '{4}')";
        public const String select_teeth_info = "select * from teeth_info";
        public const String select_teeth_info_is_permanent_based_id = "select is_permanent from teeth_info where id = '{0}'";
        public const String select_teeth_info_based_patient_id_and_number = "select * from teeth_info where patient_id = '{0}' and number = '{1}'";
        public const String select_teeth_info_id_based_patient_id_and_number = "select id from teeth_info where patient_id = '{0}' and number = '{1}'";
        public const String select_teeth_info_based_id = "select * from teeth_info where id = '{0}'";
        public const String update_teeth_info_is_permanent_based_id = "update teeth_info set is_permanent = {0} where id = '{1}'";
        public const String delete_teeth_info_based_patient_id = "delete from teeth_info where patient_id = '{0}'";
        public const String select_teeth_info_id_based_patient_id = "select id from teeth_info where patient_id = '{0}'";
        public const String select_teeth_info_based_patient_id = "select * from teeth_info where patient_id = '{0}'";
        public const String select_teeth_info_last_id = "select max(id) from teeth_info";
        public const String insert_teeth_task_info = "insert into teeth_task_info(teeth_id, task_code, cost, notes) values('{0}', '{1}', '{2}', '{3}')";
        public const String select_teeth_task_info = "select * from teeth_task_info";
        public const String select_teeth_task_info_based_teeth_id = "select * from teeth_task_info where teeth_id = '{0}'";
        public const String update_teeth_task_info_based_id = "update teeth_task_info set teeth_id = '{0}', task_id = '{1}', cost = '{2}', notes = '{3}' where id = '{4}'";
        public const String update_teeth_task_info_single_data_based_id = "update teeth_task_info set {0} = '{1}' where id = '{2}'";
        public const String delete_teeth_task_info_based_id = "delete from teeth_task_info where id = '{0}'";
        public const String delete_teeth_task_info_based_teeth_id = "delete from teeth_task_info where teeth_id = '{0}'";
        public const String select_total_teeth_task_info_based_task_code = "select count(*) as total from teeth_task_info where task_code = '{0}'";
        public const String select_percentage_teeth_task_info_based_task_code = "select ((count(*)/(select count(*) from teeth_task_info)) * 100) as percentage from teeth_task_info where task_code = '{0}'";
        public const String select_teeth_task_info_teeth_id = "select teeth_id from teeth_task_info";
        public const String update_teeth_diagram_info_is_activated_based_teeth_id_and_number = "update teeth_diagram_info set color = '{0}', is_activated = {1} where teeth_id = '{2}' and number = '{3}' and diagram = '{4}'";
        public const String update_teeth_diagram_info_turn_off_based_teeth_id = "update teeth_diagram_info set is_activated = false where teeth_id = '{0}'";
        public const String insert_teeth_diagram_info = "insert into teeth_diagram_info(color, diagram, is_activated, number, teeth_id) values('black', '{0}', false, '{1}', '{2}')";
        public const String select_teeth_diagram_info_path_based_teeth_id_and_is_activated = "select color, diagram from teeth_diagram_info where is_activated = true and teeth_id = '{0}'";
        public const String select_teeth_info_patient_id_based_id = "select patient_id from teeth_info where id = '{0}'";
        public const String select_teeth_task_info_task_code_and_teeth_id = "select task_code, teeth_id from teeth_task_info";
        public const String select_database = "show databases";
        public const String backup_database = "{0} --user={1} --password={2} {3} > {4} -B";
        public const String restore_database = "{0} --user={1} --password={2} {3} < {4}";
        public const String connection = "datasource={0};port=3306;username={1};password={2};database={3};";
        public const String use_database = "use {0}";

        public const String select_mysql_base_dir_bin = "select concat(@@basedir, '/bin/{0}')";

        public const String database_name = "dental";

        public const String user_setup_conf_file = "usersetup.json";
        public const String user_setup_conf_exe = "usersetup.exe";

        public const String database_conf_file = "dbconf.json";
        public const String database_conf_exe = "databaseconfigurator.exe";

        public const String external_exe_arg = "dentalrecord";
        
        
    }

    class DatabaseCredential
    {
        public DatabaseCredential()
        {
            host = "";
            database = "";
            username = "";
            password = "";
        }
        public string host;
        public string database;
        public string username;
        public string password;
    }
}
