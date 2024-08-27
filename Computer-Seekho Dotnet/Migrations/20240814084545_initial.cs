using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerSeekho.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumMaster",
                columns: table => new
                {
                    album_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    album_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    album_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    album_is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumMaster", x => x.album_id);
                });

            migrationBuilder.CreateTable(
                name: "ClosureReasonMaster",
                columns: table => new
                {
                    closure_reason_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    closure_reason_desc = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosureReasonMaster", x => x.closure_reason_id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypeMaster",
                columns: table => new
                {
                    payment_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_type_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypeMaster", x => x.payment_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staff_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staff_role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staff_mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staff_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staff_username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staff_password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.staff_id);
                });

            migrationBuilder.CreateTable(
                name: "ImageMaster",
                columns: table => new
                {
                    image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    album_id = table.Column<int>(type: "int", nullable: true),
                    is_album_cover = table.Column<bool>(type: "bit", nullable: true),
                    image_is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageMaster", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_ImageMaster_AlbumMaster_album_id",
                        column: x => x.album_id,
                        principalTable: "AlbumMaster",
                        principalColumn: "album_id");
                });

            migrationBuilder.CreateTable(
                name: "VideoMaster",
                columns: table => new
                {
                    video_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    video_path = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    video_url = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    album_id = table.Column<int>(type: "int", nullable: true),
                    is_album_cover = table.Column<bool>(type: "bit", nullable: true),
                    video_is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoMaster", x => x.video_id);
                    table.ForeignKey(
                        name: "FK_VideoMaster_AlbumMaster_album_id",
                        column: x => x.album_id,
                        principalTable: "AlbumMaster",
                        principalColumn: "album_id");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_duration = table.Column<int>(type: "int", nullable: true),
                    course_syllabus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age_grp_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_is_active = table.Column<bool>(type: "bit", nullable: true),
                    cover_photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    video_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_Course_VideoMaster_video_id",
                        column: x => x.video_id,
                        principalTable: "VideoMaster",
                        principalColumn: "video_id");
                });

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    batch_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    batch_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    batch_start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    batch_end_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: true),
                    final_presentation_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    batch_fees = table.Column<float>(type: "real", nullable: true),
                    course_fees_from = table.Column<DateTime>(type: "datetime2", nullable: true),
                    course_fees_to = table.Column<DateTime>(type: "datetime2", nullable: true),
                    batch_is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.batch_id);
                    table.ForeignKey(
                        name: "FK_Batch_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "Enquiry",
                columns: table => new
                {
                    enquiryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enquirer_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enquirer_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enquirer_mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enquirer_alternate_mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enquirer_emailid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enquiry_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    enquirer_query = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    closure_reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enquiry_processed_flag = table.Column<bool>(type: "bit", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: true),
                    staff_id = table.Column<int>(type: "int", nullable: true),
                    student_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enquiry_counter = table.Column<int>(type: "int", nullable: true),
                    followup_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiry", x => x.enquiryId);
                    table.ForeignKey(
                        name: "FK_Enquiry_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_Enquiry_Staff_staff_id",
                        column: x => x.staff_id,
                        principalTable: "Staff",
                        principalColumn: "staff_id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    student_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    student_gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    student_dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    student_qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    student_mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: true),
                    batch_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_Student_Batch_batch_id",
                        column: x => x.batch_id,
                        principalTable: "Batch",
                        principalColumn: "batch_id");
                    table.ForeignKey(
                        name: "FK_Student_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id");
                });

            migrationBuilder.CreateTable(
                name: "Followup",
                columns: table => new
                {
                    followupid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enquiry_id = table.Column<int>(type: "int", nullable: true),
                    staff_id = table.Column<int>(type: "int", nullable: true),
                    followup_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    followup_msg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followup", x => x.followupid);
                    table.ForeignKey(
                        name: "FK_Followup_Enquiry_enquiry_id",
                        column: x => x.enquiry_id,
                        principalTable: "Enquiry",
                        principalColumn: "enquiryId");
                    table.ForeignKey(
                        name: "FK_Followup_Staff_staff_id",
                        column: x => x.staff_id,
                        principalTable: "Staff",
                        principalColumn: "staff_id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    paymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_type_id = table.Column<int>(type: "int", nullable: true),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    student_id = table.Column<int>(type: "int", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: true),
                    batch_id = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.paymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Batch_batch_id",
                        column: x => x.batch_id,
                        principalTable: "Batch",
                        principalColumn: "batch_id");
                    table.ForeignKey(
                        name: "FK_Payment_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK_Payment_PaymentTypeMaster_payment_type_id",
                        column: x => x.payment_type_id,
                        principalTable: "PaymentTypeMaster",
                        principalColumn: "payment_type_id");
                    table.ForeignKey(
                        name: "FK_Payment_Student_student_id",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "student_id");
                });

            migrationBuilder.CreateTable(
                name: "receipt",
                columns: table => new
                {
                    receipt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receipt_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    receipt_amount = table.Column<double>(type: "float", nullable: true),
                    payment_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipt", x => x.receipt_id);
                    table.ForeignKey(
                        name: "FK_receipt_Payment_payment_id",
                        column: x => x.payment_id,
                        principalTable: "Payment",
                        principalColumn: "paymentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batch_course_id",
                table: "Batch",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_video_id",
                table: "Course",
                column: "video_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_course_id",
                table: "Enquiry",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_staff_id",
                table: "Enquiry",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_Followup_enquiry_id",
                table: "Followup",
                column: "enquiry_id");

            migrationBuilder.CreateIndex(
                name: "IX_Followup_staff_id",
                table: "Followup",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_ImageMaster_album_id",
                table: "ImageMaster",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_batch_id",
                table: "Payment",
                column: "batch_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_course_id",
                table: "Payment",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_payment_type_id",
                table: "Payment",
                column: "payment_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_student_id",
                table: "Payment",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_payment_id",
                table: "receipt",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_batch_id",
                table: "Student",
                column: "batch_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_course_id",
                table: "Student",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_VideoMaster_album_id",
                table: "VideoMaster",
                column: "album_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClosureReasonMaster");

            migrationBuilder.DropTable(
                name: "Followup");

            migrationBuilder.DropTable(
                name: "ImageMaster");

            migrationBuilder.DropTable(
                name: "receipt");

            migrationBuilder.DropTable(
                name: "Enquiry");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "PaymentTypeMaster");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "VideoMaster");

            migrationBuilder.DropTable(
                name: "AlbumMaster");
        }
    }
}
