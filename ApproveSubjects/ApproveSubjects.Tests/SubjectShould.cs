using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace ApproveSubjects.Tests
{
    public class SubjectShould
    {
        private readonly Subject _sut;
        private readonly Mock<Action<decimal>> _approveSubject = new Mock<Action<decimal>> { DefaultValue = DefaultValue.Mock };
        private readonly Mock<Action<decimal>> _recoverySubject = new Mock<Action<decimal>> { DefaultValue = DefaultValue.Mock };
        private readonly Mock<Action<decimal>> _disapproveSubject = new Mock<Action<decimal>> { DefaultValue = DefaultValue.Mock };
        public SubjectShould()
        {

            _sut = new Subject(new RulesFactory().Create(_approveSubject.Object, _recoverySubject.Object, _disapproveSubject.Object));
        }
        [Fact]
        public void Suscribe_Subject()
        {
            _sut.CloseSubject();

            _disapproveSubject.Verify(x => x(0), Times.AtLeastOnce);
        }
        [Fact]
        public void Receives_Practical_Work()
        {
            _sut.GivePracticalWork();
            _sut.CloseSubject();

            _recoverySubject.Verify(x => x(0), Times.AtLeastOnce);
        }

        [Fact]
        public void Receives_Exam_Work()
        {
            _sut.GivePracticalWork();
            _sut.GiveExam(SubjectExamNote.Create(6));
            _sut.CloseSubject();

            _recoverySubject.Verify(x => x(6), Times.AtLeastOnce);
        }

        [Fact]
        public void Receives_Final_Exam_Work()
        {
            _sut.GivePracticalWork();
            _sut.GiveExam(SubjectExamNote.Create(6));
            _sut.GiveFinalExam(SubjectFinalExamNote.Create(8));
            _sut.CloseSubject();

            _approveSubject.Verify(x => x(6 + 8), Times.AtLeastOnce);
        }
        [Fact]
        public void Receives_Final_Exam_Work2()
        {
            _sut.GivePracticalWork();
            _sut.GiveExam(SubjectExamNote.Create(6));
            _sut.GiveExam(SubjectFinalExamNote.Create(2));
            _sut.CloseSubject();

            _recoverySubject.Verify(x => x(8), Times.AtLeastOnce);
        }
    }
}
